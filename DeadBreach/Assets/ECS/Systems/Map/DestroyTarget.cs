using Entitas;

namespace DeadBreach.ECS.Systems.Map
{
    public class DestroyTarget : IExecuteSystem
    {
        private readonly IGroup<GameEntity> targets;

        public DestroyTarget(GameContext game)
        {
            targets = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Target));
        }

        public void Execute()
        {
            foreach (var target in targets) 
                target.isDestroyed = true;
        }
    }
}