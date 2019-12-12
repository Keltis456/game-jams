using Entitas;

namespace DeadBreach.ECS.Systems.PathFinding
{
    public class RemoveDestroyedPathEndTiles : IExecuteSystem
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

        public void Execute()
        {
            foreach (var agent in agents)
            foreach (var pathNode in agent.pathFinderPath.value)
            foreach (var tile in tiles.GetEntities())
                if (tile.gridPosition.value == pathNode && agent.pathFinderPath.value.IndexOf(pathNode) == agent.pathFinderPath.value.Count - 1)
                {
                    tile.isPathEndTile = false;
                    tile.isGameObjectDestroyed = true;
                    tile.isDestroyedTile = true;
                }
        }
    }
}