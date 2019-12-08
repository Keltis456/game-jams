using Entitas;

namespace DeadBreach.ECS.Systems.Touch
{
    internal class DestroyPointerEnter : ICleanupSystem
    {
        private readonly IGroup<GameEntity> handlers;

        public DestroyPointerEnter(GameContext game)
        {
            handlers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.GameObject,
                    GameMatcher.PointerEnterHandler));
        }

        public void Cleanup()
        {
            foreach (var handler in handlers.GetEntities()) 
                handler.isPointerEnter = false;
        }
    }
}