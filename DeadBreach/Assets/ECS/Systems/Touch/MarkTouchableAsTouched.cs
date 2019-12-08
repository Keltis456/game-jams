using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DeadBreach.ECS.Systems.Touch
{
    internal class MarkTouchableAsTouched : IExecuteSystem
    {
        private readonly GameContext game;
        private readonly IGroup<GameEntity> touchables;
        private readonly IGroup<GameEntity> touches;

        public MarkTouchableAsTouched(GameContext game)
        {
            this.game = game;
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
                
                var pointerData = new PointerEventData(EventSystem.current);
                var results = new List<RaycastResult>();
 
                pointerData.position = Input.mousePosition;
                game.mainCanvas.value.GetComponent<GraphicRaycaster>().Raycast(pointerData, results);
                
                foreach (var touchable in touchables)
                foreach (var result in results)
                    if (hit.collider?.gameObject == touchable.gameObject.value || result.gameObject == touchable.gameObject.value)
                        touchable.isTouched = true;
            }
        }
    }
}
