using Entitas;

namespace DeadBreach.ECS.Systems.Map
{
    public class MovePlayerToTarget : IExecuteSystem
    {
        private readonly IGroup<GameEntity> targets;
        private readonly IGroup<GameEntity> players;

        public MovePlayerToTarget(GameContext game)
        {
            targets = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Target,
                    GameMatcher.CubicPosition));
            
            players = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.CubicPosition));
        }

        public void Execute()
        {
            foreach (var player in players)
            foreach (var target in targets)
                player.ReplaceCubicPosition(target.cubicPosition.value);
        }
    }
}