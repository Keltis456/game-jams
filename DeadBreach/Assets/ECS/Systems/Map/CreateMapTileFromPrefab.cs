using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace DeadBreach.ECS.Systems.Map
{
    public class CreateMapTileFromPrefab : IExecuteSystem
    {
        private readonly GameContext game;
        private readonly GameObject mapTilePrefab;
        private readonly IGroup<GameEntity> tiles;

        public CreateMapTileFromPrefab(GameContext game, GameObject mapTilePrefab)
        {
            this.game = game;
            this.mapTilePrefab = mapTilePrefab;
            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Tile)
                .NoneOf(
                    GameMatcher.GameObject));
        }

        public void Execute()
        {
            foreach (var tile in tiles.GetEntities())
            {
                tile.ReplaceAndSetupGameObject(Object.Instantiate(mapTilePrefab, Vector3.zero, Quaternion.identity, game.mainCanvas.value.transform));
                tile.isTouchable = true;
                tile.isPointerEnterHandler = true;
                var image = tile.gameObject.value.GetComponent<Image>();
                if (image) 
                    tile.ReplaceImage(image);
            }
        }

    }
}