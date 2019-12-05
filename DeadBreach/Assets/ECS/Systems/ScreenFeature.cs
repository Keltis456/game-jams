using DeadBreach.ECS.Systems.Screen;

namespace DeadBreach.ECS.Systems
{
    internal class ScreenFeature : Feature
    {
        public ScreenFeature(GameContext game)
        {
            Add(new RegisterMainCameraAsEntity(game));
        }
    }
}
