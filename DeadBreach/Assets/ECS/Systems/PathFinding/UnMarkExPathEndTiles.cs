using Entitas;

namespace DeadBreach.ECS.Systems.PathFinding
{
    public class UnMarkExPathEndTiles :  ICleanupSystem
    {
        private readonly IGroup<GameEntity> tiles;

        public UnMarkExPathEndTiles(GameContext game)
        {
            tiles = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.ExPathEndTile));
        }

        public void Cleanup()
        {
            foreach (var tile in tiles.GetEntities()) 
                tile.isExPathEndTile = false;
        }
    }
}