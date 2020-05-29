using DeadBreach.ECS.Systems.Skills;

namespace DeadBreach.ECS
{
    public sealed class SkillFeature : Feature
    {
        public SkillFeature(GameContext game)
        {
            Add(new AddRequiredSkill(game));
        }
    }
}