using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Map
{
    public class RenderCubicPositionToTransform : IExecuteSystem
    {
        private readonly IGroup<GameEntity> entities;

        public RenderCubicPositionToTransform(GameContext game)
        {
            entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CubicPosition,
                    GameMatcher.Position));
        }

        public void Execute()
        {
            foreach (var entity in entities)
            {
                var cubicPosition = entity.cubicPosition.value;
                var quadraticColumn = cubicPosition.x * 0.86f;
                var quadraticRow = -(cubicPosition.z + cubicPosition.x * 0.5f);
                entity.ReplacePosition(new Vector3(quadraticColumn, quadraticRow, 0));
            }
        }
    }
}