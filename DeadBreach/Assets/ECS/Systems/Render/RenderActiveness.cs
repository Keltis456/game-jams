using Entitas;

namespace DeadBreach.ECS.Systems.Render
{
    public class RenderActiveness : IExecuteSystem
    {
        private readonly IGroup<GameEntity> entities;

        public RenderActiveness(GameContext game)
        {
            entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Activeness, GameMatcher.GameObject));
        }

        public void Execute()
        {
            foreach (var entity in entities) 
                entity.gameObject.value.SetActive(entity.activeness.value);
        }
    }
}