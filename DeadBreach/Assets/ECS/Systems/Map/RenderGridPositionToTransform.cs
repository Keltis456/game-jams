using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Map
{
    public class RenderGridPositionToTransform : IExecuteSystem
    {
        private readonly IGroup<GameEntity> entities;

        public RenderGridPositionToTransform(GameContext game)
        {
            entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.GridPosition,
                    GameMatcher.Position));
        }

        public void Execute()
        {
            foreach (var entity in entities)
                entity.ReplacePosition(new Vector3(entity.gridPosition.value.x, entity.gridPosition.value.y, 0));
        }
    }
}