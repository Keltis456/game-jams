using DeadBreach.ECS.Systems.Animator;

namespace DeadBreach.ECS.Systems
{
    public sealed class AnimatorFeature : Feature
    {
        public AnimatorFeature(GameContext game)
        {
            Add(new AddRequestedAnimator(game));
            Add(new RenderAnimatorFloat(game));
            Add(new RenderAnimatorInt(game));
            Add(new RenderAnimatorBool(game));
        }
    }
}