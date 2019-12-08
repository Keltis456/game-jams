using Entitas;

namespace DeadBreach.ECS.Systems.PathFinding
{
    public class UnMarkExPathTiles :  ICleanupSystem
    {
        private readonly IGroup<GameEntity> tiles;

        public UnMarkExPathTiles(GameContext game)
        {
            tiles = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.ExPathTile));
        }

        public void Cleanup()
        {
            foreach (var tile in tiles.GetEntities()) 
                tile.isExPathTile = false;
        }
    }
}