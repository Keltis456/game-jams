
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace DeadBreach.ECS.Systems.Map
{
    public class SetPathEndTileSprite : IExecuteSystem
    {
        private readonly GameContext game;
        private readonly Sprite pathTileEnd;
        private readonly IGroup<GameEntity> tiles;

        public SetPathEndTileSprite(GameContext game, Sprite pathTileEnd)
        {
            this.game = game;
            this.pathTileEnd = pathTileEnd;
            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PathEndTile,
                    GameMatcher.Image));
        }

        public void Execute()
        {
            foreach (var tile in tiles.GetEntities())
            {
                tile.ReplaceImageSprite(pathTileEnd);
            }
        }
    }
}