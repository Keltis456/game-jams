using DeadBreach.ECS.Systems.DoTween;

namespace DeadBreach.ECS.Systems
{
    internal class DoTweenFeature : Feature
    {
        public DoTweenFeature(GameContext game)
        {
            Add(new UpdateIsTweenPlaying(game));
            Add(new RemoveInactiveTween(game));

            Add(new KillDeactivatedTween(game));

            Add(new DoTweenMove(game));
        }
    }
}