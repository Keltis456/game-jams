using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DeadBreach.ECS.Systems.Touch
{
    internal class HandlePointerEnter : IExecuteSystem
    {
        private readonly GameContext game;
        private readonly IGroup<GameEntity> handlers;

        public HandlePointerEnter(GameContext game)
        {
            this.game = game;
            handlers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.GameObject,
                    GameMatcher.PointerEnterHandler));
        }

        public void Execute()
        {
            foreach (var handler in handlers)
            {
                var pointerData = new PointerEventData(EventSystem.current);
                var results = new List<RaycastResult>();
 
                pointerData.position = Input.mousePosition;
                game.mainCanvas.value.GetComponent<GraphicRaycaster>().Raycast(pointerData, results);
                
                foreach (var result in results)
                    if (result.gameObject == handler.gameObject.value)
                        handler.isPointerEnter = true;
            }
        }
    }
}