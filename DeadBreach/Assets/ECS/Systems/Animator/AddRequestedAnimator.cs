using Entitas;

namespace DeadBreach.ECS.Systems.Animator
{
    public class AddRequestedAnimator : IExecuteSystem
    {
        private readonly IGroup<GameEntity> entities;

        public AddRequestedAnimator(GameContext game)
        {
            entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.UnityAnimatorRequested, GameMatcher.GameObject)
                .NoneOf(GameMatcher.UnityAnimator));
        }

        public void Execute()
        {
            foreach (var entity in entities.GetEntities())
            {
                var go = entity.gameObject.value.transform.GetChild(0).gameObject;
                entity.ReplaceUnityAnimator(go.GetComponent<UnityEngine.Animator>() ?? go.AddComponent<UnityEngine.Animator>());
            }
        }
    }
}