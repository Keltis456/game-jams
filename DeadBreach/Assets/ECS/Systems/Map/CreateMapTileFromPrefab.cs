using DeadBreach.ECS.Behaviours;
using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Map
{
    public class CreateMapTileFromPrefab : IExecuteSystem
    {
        private readonly Canvas canvas;
        private readonly GameObject mapTilePrefab;
        private readonly IGroup<GameEntity> entities;

        public CreateMapTileFromPrefab(GameContext game, Canvas canvas, GameObject mapTilePrefab)
        {
            this.canvas = canvas;
            this.mapTilePrefab = mapTilePrefab;
            entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Tile)
                .NoneOf(
                    GameMatcher.GameObject));
        }

        public void Execute()
        {
            foreach (var entity in entities.GetEntities())
            {
                entity.AddId(entity.creationIndex);
                entity.AddGameObject(Object.Instantiate(mapTilePrefab, canvas.transform));
                
                entity.AddPosition(mapTilePrefab.transform.position);
                entity.AddRotation(mapTilePrefab.transform.rotation.eulerAngles);
                entity.AddScale(mapTilePrefab.transform.localScale);
                
                entity.isTouchable = true;
            }
        }
    }
}