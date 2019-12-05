using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Touch
{
    internal class CreateTouchOnLeftMouseDown : IExecuteSystem
    {
        private readonly GameContext game;

        public CreateTouchOnLeftMouseDown(GameContext game) =>
            this.game = game;

        public void Execute()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var touch = game.CreateEntity();
                touch.isTouch = true;
                touch.AddPosition(game.mainCamera.value.ScreenToWorldPoint(Input.mousePosition));
            }
        }
    }
}
