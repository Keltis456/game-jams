using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Touch
{
    internal class MarkTouchableAsTouched : IExecuteSystem
    {
        private readonly IGroup<GameEntity> touchables;
        private readonly IGroup<GameEntity> touches;

        public MarkTouchableAsTouched(GameContext game)
        {
            touchables = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.GameObject, GameMatcher.Touchable));

            touches = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Touch, GameMatcher.Position));
        }

        public void Execute()
        {
            foreach (var touch in touches)
            {
                var hit = Physics2D.Raycast(touch.position.value, Vector2.zero);

                foreach (var touchable in touchables)
                    if (hit.collider?.gameObject == touchable.gameObject.value)
                        touchable.isTouched = true;
            }
        }
    }
}
