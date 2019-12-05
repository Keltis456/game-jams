using DeadBreach.ECS.Systems.Screen;
using UnityEngine;

namespace DeadBreach.ECS.Systems
{
    internal sealed class ScreenFeature : Feature
    {
        public ScreenFeature(GameContext game, Canvas canvas)
        {
            Add(new RegisterMainCameraAsEntity(game));
            Add(new RegisterCanvasAsEntity(game, canvas));
        }
    }
}
