using Entitas;

namespace DeadBreach.ECS.Systems.PathFinding
{
    public class UnMarkDestroyedTiles :  ICleanupSystem
    {
        private readonly IGroup<GameEntity> tiles;

        public UnMarkDestroyedTiles(GameContext game)
        {
            tiles = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.DestroyedTile));
        }

        public void Cleanup()
        {
            foreach (var tile in tiles.GetEntities()) 
                tile.isDestroyedTile = false;
        }
    }
}