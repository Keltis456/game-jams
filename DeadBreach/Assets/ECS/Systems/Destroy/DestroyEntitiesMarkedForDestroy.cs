using Entitas;

namespace DeadBreach.ECS.Systems.Destroy
{
	internal class DestroyEntitiesMarkedForDestroy : ICleanupSystem
	{
		private readonly IGroup<GameEntity> entities;

		public DestroyEntitiesMarkedForDestroy(GameContext game) =>
			entities = game.GetGroup(GameMatcher.AllOf(GameMatcher.Destroyed));
		
		public void Cleanup()
		{
			foreach (var entity in entities.GetEntities())
                entity.Destroy();
		}
	}
}
