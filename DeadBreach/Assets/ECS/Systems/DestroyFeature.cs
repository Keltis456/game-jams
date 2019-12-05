using DeadBreach.ECS.Systems.Destroy;

namespace DeadBreach.ECS.Systems
{
	internal sealed class DestroyFeature : Feature
	{
		public DestroyFeature(GameContext game)
		{
			Add(new DestroyGameObjectsMarkedForDestroy(game));
			Add(new DestroyEntitiesMarkedForDestroy(game));
		}
	}
}
