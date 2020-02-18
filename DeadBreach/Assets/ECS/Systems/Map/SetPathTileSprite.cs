
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace DeadBreach.ECS.Systems.Map
{
    public class SetPathTileSprite : IExecuteSystem
    {
        private readonly GameContext game;
        private readonly Sprite pathTile;
        private readonly IGroup<GameEntity> tiles;

        public SetPathTileSprite(GameContext game, Sprite pathTile)
        {
            this.game = game;
            this.pathTile = pathTile;
            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PathTile,
                    GameMatcher.Image));
        }

        public void Execute()
        {
            foreach (var tile in tiles.GetEntities())
            {
                tile.ReplaceImageSprite(pathTile);
            }
        }
    }
}