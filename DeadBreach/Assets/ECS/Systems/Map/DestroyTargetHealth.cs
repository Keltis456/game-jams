using Entitas;

namespace DeadBreach.ECS.Systems.Map
{
    public class DestroyTargetHealth : IExecuteSystem
    {
        private readonly GameContext game;
        private readonly IGroup<GameEntity> targets;

        public DestroyTargetHealth(GameContext game)
        {
            this.game = game;
            targets = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Target, GameMatcher.TileHealthLink));
        }

        public void Execute()
        {
            foreach (var target in targets) 
                game.GetEntityWithId(target.tileHealthLink.id).isDestroyed = true;
        }
    }
}