using Entitas;

namespace DeadBreach.ECS.Systems.Skills
{
    public class AddRequiredSkill : IExecuteSystem
    {
        private readonly GameContext game;
        private readonly IGroup<GameEntity> owners;
        private readonly IGroup<GameEntity> skills;

        public AddRequiredSkill(GameContext game)
        {
            this.game = game;
            owners = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.RequireSkillOnSlot,
                    GameMatcher.Id));

            skills = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.SkillOwnerId,
                    GameMatcher.SkillSlotIndex));
        }

        public void Execute()
        {
            foreach (var owner in owners.GetEntities())
            {
                foreach (var skill in skills.GetEntities())
                {
                    if (skill.skillOwnerId.value != owner.id.value) continue;
                    if (skill.skillSlotIndex.value != owner.requireSkillOnSlot.index) continue;
                    skill.isDestroyed = true;
                    skill.RemoveSkillOwnerId();
                }
                var newSkill = owner.requireSkillOnSlot.value.CreateSkill(game);
                newSkill.AddSkillOwnerId(owner.id.value);
                newSkill.AddSkillSlotIndex(owner.requireSkillOnSlot.index);
                owner.RemoveRequireSkillOnSlot();
            }
        }
    }
}