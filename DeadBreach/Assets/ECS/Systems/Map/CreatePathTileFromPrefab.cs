using DeadBreach.ECS.Extensions;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace DeadBreach.ECS.Systems.Map
{
    public class CreatePathTileFromPrefab : IExecuteSystem
    {
        private readonly GameContext game;
        private readonly GameObject pathTilePrefab;
        private readonly IGroup<GameEntity> tiles;

        public CreatePathTileFromPrefab(GameContext game, GameObject pathTilePrefab)
        {
            this.game = game;
            this.pathTilePrefab = pathTilePrefab;
            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PathTile)
                .NoneOf(
                    GameMatcher.GameObject));
        }

        public void Execute()
        {
            foreach (var tile in tiles.GetEntities())
            {
                tile.ReplaceAndSetupGameObject(Object.Instantiate(pathTilePrefab, Vector3.zero, Quaternion.identity, game.mainCanvas.value.transform));
                tile.isTouchable = true;

                var image = tile.gameObject.value.GetComponent<Image>();
                if (image) 
                    tile.ReplaceImage(image);
            }
        }
    }
}