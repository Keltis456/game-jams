using Entitas;

namespace DeadBreach.ECS.Systems.Map
{
    public class DestroyTargetIcon : IExecuteSystem
    {
        private readonly GameContext game;
        private readonly IGroup<GameEntity> targets;

        public DestroyTargetIcon(GameContext game)
        {
            this.game = game;
            targets = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Target, GameMatcher.TileIconLink));
        }

        public void Execute()
        {
            foreach (var target in targets) 
                game.GetEntityWithId(target.tileIconLink.id).isDestroyed = true;
        }
    }
}