using Entitas;

namespace DeadBreach.ECS.Systems.Render
{
    public class RenderImageSprite : IExecuteSystem
    {
        private readonly IGroup<GameEntity> images;

        public RenderImageSprite(GameContext game) =>
            images = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Image, GameMatcher.ImageSprite));

        public void Execute()
        {
            foreach (var image in images)
                if (image.image.value.sprite != image.imageSprite.value)
                    image.image.value.sprite = image.imageSprite.value;
        }
    }
}