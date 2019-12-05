using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Screen
{
    internal class RegisterMainCameraAsEntity : IInitializeSystem
    {
        private readonly GameContext game;

        public RegisterMainCameraAsEntity(GameContext game) =>
            this.game = game;

        public void Initialize() => 
            game.SetMainCamera(Camera.main);
    }
}
