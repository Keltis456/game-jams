using Entitas;

namespace DeadBreach.ECS.Systems.Map
{
    public class DestroyTargetName : IExecuteSystem
    {
        private readonly GameContext game;
        private readonly IGroup<GameEntity> targets;

        public DestroyTargetName(GameContext game)
        {
            this.game = game;
            targets = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Target, GameMatcher.TileNameLink));
        }

        public void Execute()
        {
            foreach (var target in targets) 
                game.GetEntityWithId(target.tileNameLink.id).isDestroyed = true;
        }
    }
}