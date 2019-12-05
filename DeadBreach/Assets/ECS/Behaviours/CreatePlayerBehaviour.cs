using UnityEngine;

namespace DeadBreach.ECS.Behaviours
{
    public class CreatePlayerBehaviour : MonoBehaviour
    {
        private static GameContext Game => Contexts.sharedInstance.game;

        private void Start()
        {
            var entity = Game.CreateEntity();

            entity.isTile = true;
            entity.AddId(entity.creationIndex);
            entity.AddCubicPosition(Vector3Int.zero);

            entity.isPlayer = true;
            entity.AddTileName("True Hero");

            entity.AddTileHealth(10);
            entity.AddTileMaxHealth(10);

            entity.isTouchable = true;
            entity.AddGameObject(gameObject);

            entity.AddPosition(transform.position);
            entity.AddRotation(transform.rotation.eulerAngles);
            entity.AddScale(transform.localScale);
            
            var hexagonUI = entity.gameObject.value.GetComponent<TileUIDependencies>();
            if (hexagonUI)
            {
                var name = Game.CreateEntity();
                name.AddText("");
                name.AddGameObject(hexagonUI.name.gameObject);
                name.AddTextMeshProText(hexagonUI.name);
                name.AddId(name.creationIndex);
                name.AddTileLink(entity.id.value);
                entity.AddTileNameLink(name.creationIndex);

                var health = Game.CreateEntity();
                health.AddText("");
                health.AddGameObject(hexagonUI.health.gameObject);
                health.AddTextMeshProText(hexagonUI.health);
                health.AddId(health.creationIndex);
                health.AddTileLink(entity.id.value);
                entity.AddTileHealthLink(health.creationIndex);

                var icon = Game.CreateEntity();
                icon.AddGameObject(hexagonUI.icon.gameObject);
                icon.AddId(icon.creationIndex);
                icon.AddTileLink(entity.id.value);
                entity.AddTileIconLink(icon.creationIndex);


                name.AddTextColor(Color.yellow);

            }
        }
    }
}
