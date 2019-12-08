using DeadBreach.ECS.Extensions;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace DeadBreach.ECS.Systems.Map
{
    public class CreatePathEndTileFromPrefab : IExecuteSystem
    {
        private readonly GameContext game;
        private readonly GameObject pathTileEndPrefab;
        private readonly IGroup<GameEntity> tiles;

        public CreatePathEndTileFromPrefab(GameContext game, GameObject pathTileEndPrefab)
        {
            this.game = game;
            this.pathTileEndPrefab = pathTileEndPrefab;
            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PathEndTile)
                .NoneOf(
                    GameMatcher.GameObject));
        }

        public void Execute()
        {
            foreach (var tile in tiles.GetEntities())
            {
                tile.ReplaceAndSetupGameObject(Object.Instantiate(pathTileEndPrefab, Vector3.zero, Quaternion.identity, game.mainCanvas.value.transform));
                tile.isTouchable = true;

                var image = tile.gameObject.value.GetComponent<Image>();
                if (image) 
                    tile.ReplaceImage(image);
            }
        }
    }
}