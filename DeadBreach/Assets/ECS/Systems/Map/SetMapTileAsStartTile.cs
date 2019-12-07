using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Map
{
    public class SetMapTileAsStartTile : IExecuteSystem
    {
        private readonly Vector2Int startPosition = new Vector2Int(4,0); 

        private readonly IGroup<GameEntity> tiles;

        public SetMapTileAsStartTile(GameContext game)
        {
            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Tile,
                    GameMatcher.GridPosition)
                .NoneOf(GameMatcher.StartTile));
        }

        public void Execute()
        {
            foreach (var tile in tiles.GetEntities())
                if (tile.gridPosition.value == startPosition)
                    tile.isStartTile = true;
        }
    }
}