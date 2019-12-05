using Entitas;

namespace DeadBreach.ECS.Systems.Animator
{
    public class RenderAnimatorBool : IExecuteSystem
    {
        private readonly IGroup<GameEntity> entities;

        public RenderAnimatorBool(GameContext game)
        {
            entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.UnityAnimatorBool));
        }

        public void Execute()
        {
            foreach (var entity in entities)
            {
                entity.unityAnimatorBool.animator.SetBool(entity.unityAnimatorBool.name, entity.unityAnimatorBool.value);
                entity.isDestroyed = true;
            }
        }
    }
}