using Entitas;

namespace DeadBreach.ECS.Skills
{
    public interface ISkill
    {
        GameEntity CreateSkill(GameContext game);
    }
}