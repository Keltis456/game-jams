using Entitas;

namespace DeadBreach.ECS.Systems.Text
{
    internal class SetColorToTextMeshPro : IExecuteSystem
    {
        private readonly IGroup<GameEntity> entities;

        public SetColorToTextMeshPro(GameContext game)
        {
            entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.TextColor, GameMatcher.TextMeshProText));
        }

        public void Execute()
        {
            foreach (var entity in entities)
                entity.textMeshProText.value.color = entity.textColor.value;
        }
    }
}