using DeadBreach.ECS.Systems.Text;

namespace DeadBreach.ECS.Systems
{
    internal sealed class TextFeature : Feature
    {
        public TextFeature(GameContext game)
        {
            Add(new SetTextToTextMeshPro(game));
            Add(new SetColorToTextMeshPro(game));
        }
    }
}