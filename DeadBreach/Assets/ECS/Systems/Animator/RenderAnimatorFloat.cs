using Entitas;

namespace DeadBreach.ECS.Systems.Animator
{
    public class RenderAnimatorFloat : IExecuteSystem
    {
        private readonly IGroup<GameEntity> entities;

        public RenderAnimatorFloat(GameContext game)
        {
            entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.UnityAnimatorFloat));
        }

        public void Execute()
        {
            foreach (var entity in entities)
            {
                entity.unityAnimatorFloat.animator.SetFloat(entity.unityAnimatorFloat.name, entity.unityAnimatorFloat.value);
                entity.isDestroyed = true;
            }
        }
    }
}