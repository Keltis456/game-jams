using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Screen
{
    internal class RegisterCanvasAsEntity : IInitializeSystem
    {
        private readonly GameContext game;
        private readonly Canvas canvas;

        public RegisterCanvasAsEntity(GameContext game, Canvas canvas)
        {
            this.game = game;
            this.canvas = canvas;
        }

        public void Initialize() => 
            game.SetMainCanvas(canvas);
    }
}