using DG.Tweening;
using Entitas;

namespace DeadBreach.ECS.Systems.DoTween
{
    internal class RemoveInactiveTween : ICleanupSystem
    {
        private readonly IGroup<GameEntity> tweens;

        public RemoveInactiveTween(GameContext game) =>
            tweens = game.GetGroup(GameMatcher.AllOf(GameMatcher.Tween));

        public void Cleanup()
        {
            foreach (var entity in tweens.GetEntities())
                if (!entity.tween.value.active)
                    entity.RemoveTween();
        }
    }
}
