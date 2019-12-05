using Entitas;

namespace DeadBreach.ECS.Systems.Text
{
    internal class SetTextToTextMeshPro : IExecuteSystem
    {
        private readonly IGroup<GameEntity> entities;

        public SetTextToTextMeshPro(GameContext game)
        {
            entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Text, GameMatcher.TextMeshProText));
        }

        public void Execute()
        {
            foreach (var entity in entities) 
                entity.textMeshProText.value.SetText(entity.text.value);
        }
    }
}