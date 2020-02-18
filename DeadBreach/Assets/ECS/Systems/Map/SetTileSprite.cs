using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Map
{
    public class SetTileSprite : IExecuteSystem
    {
        private readonly GameContext game;
        private readonly Sprite mapTile;
        private readonly IGroup<GameEntity> tiles;

        public SetTileSprite(GameContext game, Sprite mapTile)
        {
            this.game = game;
            this.mapTile = mapTile;
            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Tile,
                    GameMatcher.Image));
        }

        public void Execute()
        {
            foreach (var tile in tiles.GetEntities())
            {
                tile.ReplaceImageSprite(mapTile);
            }
        }
    }
}