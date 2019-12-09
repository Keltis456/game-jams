using Entitas;

namespace DeadBreach.ECS.Systems.DoTween
{
    internal class UpdateIsTweenPlaying : ICleanupSystem
    {
        private readonly IGroup<GameEntity> tweens;

        public UpdateIsTweenPlaying(GameContext game) =>
            tweens = game.GetGroup(GameMatcher.AllOf(GameMatcher.Tween));

        public void Cleanup()
        {
            foreach (var entity in tweens.GetEntities())
                entity.isTweenPlaying = entity.tween.value.active;
        }
    }
}
