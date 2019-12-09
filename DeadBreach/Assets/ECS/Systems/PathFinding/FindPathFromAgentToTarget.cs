
using DeadBreach.ECS.Systems.Map;
using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.PathFinding
{
    public class FindPathFromAgentToTarget : IExecuteSystem
    {
        private readonly IGroup<GameEntity> agents;
        private readonly IGroup<GameEntity> tiles;
        private readonly IGroup<GameEntity> obstacles;

        public FindPathFromAgentToTarget(GameContext game)
        {
            agents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PathFinderAgent,
                    GameMatcher.GridPosition,
                    GameMatcher.Target)
                .NoneOf(
                    GameMatcher.PathFinderPath));

            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Tile, 
                    GameMatcher.GridPosition));

            obstacles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PathFinderObstacle,
                    GameMatcher.GridPosition));
        }

        public void Execute()
        {
            foreach (var agent in agents.GetEntities())
            {
                if (agent.target.value.IsAnyObstacle(obstacles.GetEntities()))
                {
                    agent.RemoveTarget();
                    continue;
                }

                var path = agent.gridPosition.value.FindPathToTile(agent.target.value, tiles.GetEntities(), obstacles.GetEntities(), new Vector2Int(InitializeMapWithNewTiles.SizeX, InitializeMapWithNewTiles.SizeY));
                if (path != null && path.Count > 0)
                {
                    agent.AddPathFinderPath(path);
                    break;
                }
            }
        }

        
    }
}