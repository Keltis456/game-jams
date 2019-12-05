using Entitas;

namespace DeadBreach.ECS.Systems.Render
{
    public class RenderImageColor : IExecuteSystem
    {
        private readonly IGroup<GameEntity> images;

        public RenderImageColor(GameContext game) =>
            images = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Image, GameMatcher.ImageColor));

        public void Execute()
        {
            foreach (var image in images)
                if (image.image.value.color != image.imageColor.value)
                    image.image.value.color = image.imageColor.value;
        }
    }
}