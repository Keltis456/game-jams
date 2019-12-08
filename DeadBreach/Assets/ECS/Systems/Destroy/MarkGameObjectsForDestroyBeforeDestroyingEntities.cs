using Entitas;

namespace DeadBreach.ECS.Systems.Destroy
{
    internal class MarkGameObjectsForDestroyBeforeDestroyingEntities : ICleanupSystem
    {
        private readonly IGroup<GameEntity> entities;

        public MarkGameObjectsForDestroyBeforeDestroyingEntities(GameContext game) =>
            entities = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Destroyed,
                    GameMatcher.GameObject));
		
        public void Cleanup()
        {
            foreach (var entity in entities.GetEntities()) 
                entity.isGameObjectDestroyed = true;
        }
    }
}