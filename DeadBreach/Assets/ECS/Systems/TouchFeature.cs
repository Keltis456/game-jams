using DeadBreach.ECS.Systems.Touch;

namespace DeadBreach.ECS.Systems
{
    internal class TouchFeature : Feature
    {
        public TouchFeature(GameContext game)
        {
            Add(new DisableSimulateMouseWithTouches());

            Add(new CreateTouchOnLeftMouseDown(game));
            Add(new CreateTouchWhenTouchBegan(game));

            Add(new MarkTouchAsDestroyed(game));

            Add(new MarkTouchableAsTouched(game));

            Add(new UnmarkTouchedTouchables(game));
        }
    }
}
