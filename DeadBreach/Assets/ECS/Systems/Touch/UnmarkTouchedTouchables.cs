using Entitas;

namespace DeadBreach.ECS.Systems.Touch
{
    internal class UnmarkTouchedTouchables : ICleanupSystem
    {
        private readonly IGroup<GameEntity> touchedTouchables;

        public UnmarkTouchedTouchables(GameContext game) =>
            touchedTouchables = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Touched, GameMatcher.Touchable));

        public void Cleanup()
        {
            foreach (var touchable in touchedTouchables.GetEntities())
                touchable.isTouched = false;
        }
    }
}
