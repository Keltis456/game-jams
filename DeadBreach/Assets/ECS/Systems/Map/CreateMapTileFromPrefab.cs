using DeadBreach.ECS.Behaviours;
using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Map
{
    public class CreateMapTileFromPrefab : IExecuteSystem
    {
        private readonly GameContext game;
        private readonly GameObject mapTilePrefab;
        private readonly IGroup<GameEntity> entities;

        public CreateMapTileFromPrefab(GameContext game, GameObject mapTilePrefab)
        {
            this.game = game;
            this.mapTilePrefab = mapTilePrefab;
            entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Tile,
                    GameMatcher.CubicPosition)
                .NoneOf(
                    GameMatcher.GameObject));
        }

        public void Execute()
        {
            foreach (var entity in entities.GetEntities())
            {
                entity.AddId(entity.creationIndex);
                entity.AddGameObject(Object.Instantiate(mapTilePrefab));
                
                entity.AddPosition(mapTilePrefab.transform.position);
                entity.AddRotation(mapTilePrefab.transform.rotation.eulerAngles);
                entity.AddScale(mapTilePrefab.transform.localScale);
                
                entity.isTouchable = true;
                
                var hexagonUI = entity.gameObject.value.GetComponent<TileUIDependencies>();
                if (hexagonUI)
                {
                    var name = game.CreateEntity();
                    name.AddText("");
                    name.AddGameObject(hexagonUI.name.gameObject);
                    name.AddTextMeshProText(hexagonUI.name);
                    name.AddId(name.creationIndex);
                    name.AddTileLink(entity.id.value);
                    entity.AddTileNameLink(name.creationIndex);

                    var health = game.CreateEntity();
                    health.AddText("");
                    health.AddGameObject(hexagonUI.health.gameObject);
                    health.AddTextMeshProText(hexagonUI.health);
                    health.AddId(health.creationIndex);
                    health.AddTileLink(entity.id.value);
                    entity.AddTileHealthLink(health.creationIndex);

                    var icon = game.CreateEntity();
                    icon.AddGameObject(hexagonUI.icon.gameObject);
                    icon.AddId(icon.creationIndex);
                    icon.AddTileLink(entity.id.value);
                    entity.AddTileIconLink(icon.creationIndex);
                }

                //var spriteRenderer = entity.gameObject.value.GetComponent<SpriteRenderer>();
                //if (spriteRenderer)
                //    spriteRenderer.color = Color.HSVToRGB(Random.value, 1, 1);
            }
        }
    }
}