using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Destroy
{
	internal class DestroyGameObjectsMarkedForDestroy : ICleanupSystem
	{
		private readonly IGroup<GameEntity> entities;

		public DestroyGameObjectsMarkedForDestroy(GameContext game) =>
			entities = game.GetGroup(
				GameMatcher.AllOf(
					GameMatcher.GameObjectDestroyed,
					GameMatcher.GameObject));
		
		public void Cleanup()
		{
			foreach (var entity in entities.GetEntities())
			{
				Object.Destroy(entity.gameObject.value);
				entity.RemoveGameObject();
                entity.isGameObjectDestroyed = false;
            }
		}
	}
}
