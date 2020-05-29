using Entitas;

namespace DeadBreach.ECS.Skills
{
    public class SkillSword : ISkill
    {
        public GameEntity CreateSkill(GameContext game)
        {
            var skill = game.CreateEntity();
            skill.AddSkillName("Sword");
            skill.isSkill = true;
            skill.AddSkillEffectDamage(1);
            return skill;
        }
    }
}