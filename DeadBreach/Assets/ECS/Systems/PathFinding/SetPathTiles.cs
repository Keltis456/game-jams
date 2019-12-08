using Entitas;

namespace DeadBreach.ECS.Systems.PathFinding
{
    public class SetPathTiles : IExecuteSystem
    {
        private readonly IGroup<GameEntity> agents;
        private readonly IGroup<GameEntity> tiles;

        public SetPathTiles(GameContext game)
        {
            agents = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.PathFinderAgent, GameMatcher.PathFinderPath));
            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Tile, 
                    GameMatcher.GridPosition)
                .NoneOf(
                    GameMatcher.PathTile));
        }

        public void Execute()
        {
            foreach (var agent in agents)
            foreach (var pathNode in agent.pathFinderPath.value)
            foreach (var tile in tiles.GetEntities())
                if(tile.gridPosition.value == pathNode && agent.pathFinderPath.value.IndexOf(pathNode) != agent.pathFinderPath.value.Count-1)
                {
                    tile.isPathTile = true;
                    tile.isGameObjectDestroyed = true;
                }
        }
    }
}