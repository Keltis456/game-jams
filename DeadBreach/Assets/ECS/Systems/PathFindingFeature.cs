using System;
using DeadBreach.ECS.Systems.PathFinding;
using Entitas;

namespace DeadBreach.ECS.Systems
{
    public sealed class PathFindingFeature : Feature
    {
        public PathFindingFeature(GameContext game)
        {
            Add(new FindPathFromAgentToTarget(game));
            Add(new SetPathTiles(game));
            Add(new SetPathEndTiles(game));

            Add(new RemoveDestroyedPathTiles(game));
            Add(new RemoveDestroyedPathEndTiles(game));
            Add(new RemoveDestroyedPath(game));

        }
    }

    public class RemoveDestroyedPath : ICleanupSystem
    {
        private readonly IGroup<GameEntity> agents;

        public RemoveDestroyedPath(GameContext game)
        {
            agents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PathFinderAgent,
                    GameMatcher.PathFinderPath,
                    GameMatcher.PathDestroyed));
        }

        public void Cleanup()
        {
            foreach (var agent in agents.GetEntities())
            {
                agent.isPathDestroyed = false;
                agent.RemovePathFinderPath();
            }
        }
    }

    public class RemoveDestroyedPathEndTiles : ICleanupSystem
    {
        private readonly IGroup<GameEntity> agents;
        private readonly IGroup<GameEntity> tiles;

        public RemoveDestroyedPathEndTiles(GameContext game)
        {
            agents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PathFinderAgent,
                    GameMatcher.PathFinderPath,
                    GameMatcher.PathDestroyed));

            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Tile,
                    GameMatcher.GridPosition,
                    GameMatcher.PathEndTile));
        }

        public void Cleanup()
        {
            foreach (var agent in agents)
            foreach (var pathNode in agent.pathFinderPath.value)
            foreach (var tile in tiles.GetEntities())
                if (tile.gridPosition.value == pathNode && agent.pathFinderPath.value.IndexOf(pathNode) == agent.pathFinderPath.value.Count - 1)
                {
                    tile.isPathEndTile = false;
                    tile.isGameObjectDestroyed = true;
                }
        }
    }

    public class RemoveDestroyedPathTiles : ICleanupSystem
    {
        private readonly IGroup<GameEntity> agents;
        private readonly IGroup<GameEntity> tiles;

        public RemoveDestroyedPathTiles(GameContext game)
        {
            agents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PathFinderAgent,
                    GameMatcher.PathFinderPath,
                    GameMatcher.PathDestroyed));

            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Tile,
                    GameMatcher.GridPosition,
                    GameMatcher.PathTile));
        }

        public void Cleanup()
        {
            foreach (var agent in agents)
                foreach (var pathNode in agent.pathFinderPath.value)
                    foreach (var tile in tiles.GetEntities())
                        if (tile.gridPosition.value == pathNode && agent.pathFinderPath.value.IndexOf(pathNode) != agent.pathFinderPath.value.Count - 1)
                        {
                            tile.isPathTile = false;
                            tile.isGameObjectDestroyed = true;
                        }
        }
    }
}