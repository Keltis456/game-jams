using DG.Tweening;
using Entitas;

namespace DeadBreach.ECS.Systems.DoTween
{
    internal class KillDeactivatedTween : IExecuteSystem
    {
        private readonly IGroup<GameEntity> tweens;

        public KillDeactivatedTween(GameContext game) =>
            tweens = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Tween)
                .NoneOf(GameMatcher.TweenPlaying));

        public void Execute()
        {
            foreach (var entity in tweens.GetEntities())
            {
                entity.tween.value.Kill();
                entity.RemoveTween();
            }
        }
    }
}
