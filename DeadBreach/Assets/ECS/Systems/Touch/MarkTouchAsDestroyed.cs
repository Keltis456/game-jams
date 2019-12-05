using Entitas;

namespace DeadBreach.ECS.Systems.Touch
{
    internal class MarkTouchAsDestroyed : IExecuteSystem
    {
        private readonly IGroup<GameEntity> touches;

        public MarkTouchAsDestroyed(GameContext game) =>
            touches = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Touch)
                .NoneOf(GameMatcher.Destroyed));

        public void Execute()
        {
            foreach (var touch in touches.GetEntities())
                touch.isDestroyed = true;
        }
    }
}
