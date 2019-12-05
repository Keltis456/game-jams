using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Render
{
	public class RenderRotation : IExecuteSystem
	{
        private readonly IGroup<GameEntity> entities;

        public RenderRotation(GameContext game) =>
            entities = game.GetGroup(GameMatcher.AllOf(GameMatcher.GameObject, GameMatcher.Rotation));

        public void Execute()
        {
            foreach (var entity in entities)
                entity.gameObject.value.transform.localRotation = Quaternion.Euler(entity.rotation.value);
        }
    }
}
