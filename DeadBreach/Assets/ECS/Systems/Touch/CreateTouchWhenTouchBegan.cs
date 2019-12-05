using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Touch
{
    internal class CreateTouchWhenTouchBegan : IExecuteSystem
    {
        private readonly GameContext game;

        public CreateTouchWhenTouchBegan(GameContext game) =>
            this.game = game;

        public void Execute()
        {
            foreach (UnityEngine.Touch touch in Input.touches)
                if (touch.phase == TouchPhase.Began)
                {
                    var touchEntity = game.CreateEntity();
                    touchEntity.isTouch = true;
                    touchEntity.AddPosition(game.mainCamera.value.ScreenToWorldPoint(touch.position));
                }
        }
    }
}
