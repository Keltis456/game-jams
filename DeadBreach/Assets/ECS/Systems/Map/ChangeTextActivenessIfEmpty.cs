using Entitas;

namespace DeadBreach.ECS.Systems.Map
{
    public class ChangeTextActivenessIfEmpty : IExecuteSystem
    {
        private readonly IGroup<GameEntity> entities;

        public ChangeTextActivenessIfEmpty(GameContext game)
        {
            entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Text));
        }

        public void Execute()
        {
            foreach (var entity in entities) 
                entity.ReplaceActiveness(entity.text.value != "");
        }
    }
}