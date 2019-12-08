using System;
using DeadBreach.ECS.Systems.Touch;

namespace DeadBreach.ECS.Systems
{
    internal sealed class TouchFeature : Feature
    {
        public TouchFeature(GameContext game)
        {
            Add(new DisableSimulateMouseWithTouches());

            Add(new CreateTouchOnLeftMouseDown(game));
            Add(new CreateTouchWhenTouchBegan(game));
            Add(new MarkTouchAsDestroyed(game));

            Add(new MarkTouchableAsTouched(game));
            Add(new HandlePointerEnter(game));

            Add(new DestroyPointerEnter(game));
            Add(new UnmarkTouchedTouchables(game));
        }
    }
}
