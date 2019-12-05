using Entitas;

namespace DeadBreach.ECS.Systems.Animator
{
    public class RenderAnimatorInt : IExecuteSystem
    {
        private readonly IGroup<GameEntity> entities;

        public RenderAnimatorInt(GameContext game)
        {
            entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.UnityAnimatorInt));
        }

        public void Execute()
        {
            foreach (var entity in entities)
            {
                entity.unityAnimatorInt.animator.SetInteger(entity.unityAnimatorInt.name, entity.unityAnimatorInt.value);
                entity.isDestroyed = true;
            }
        }
    }
}