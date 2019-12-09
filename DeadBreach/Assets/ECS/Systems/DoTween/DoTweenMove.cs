using DG.Tweening;
using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.DoTween
{
    internal class DoTweenMove : IExecuteSystem
    {
        private readonly IGroup<GameEntity> gameObjects;

        public DoTweenMove(GameContext game)
        {
            gameObjects = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.GameObject, GameMatcher.TweenMove)
                .NoneOf(GameMatcher.Tween));
        }

        public void Execute()
        {
            foreach (var entity in gameObjects.GetEntities())
            {
                var transformTo = entity.tweenMove.to;

                entity.AddTween(
                    TweenMove(
                        entity.gameObject.value.transform,
                        transformTo,
                        0.5f));

                entity.ReplacePosition(transformTo.Position);
                entity.ReplaceRotation(transformTo.Rotation);
                entity.ReplaceScale(transformTo.Scale);

                entity.RemoveTweenMove();
            }
        }

        private static Sequence TweenMove(Transform transform, TweenTransform transformTo, float duration) =>
            DOTween
                .Sequence()
                .Append(transform.DOMove(transformTo.Position, duration))
                .Insert(0, transform.DORotate(transformTo.Rotation, duration))
                .Insert(0, transform.DOScale(transformTo.Scale, duration))
        ;
    }
}
