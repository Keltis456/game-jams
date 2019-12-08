using Entitas;

namespace DeadBreach.ECS.Systems.Map
{
    public class RemoveOldNonConfirmedTargetAndPlayerPathOnPointerEnter : IExecuteSystem
    {
        private readonly IGroup<GameEntity> tiles;
        private readonly IGroup<GameEntity> players;

        public RemoveOldNonConfirmedTargetAndPlayerPathOnPointerEnter(GameContext game)
        {
            players = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.Target,
                    GameMatcher.PathFinderPath));

            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PointerEnter,
                    GameMatcher.Image));
        }

        public void Execute()
        {
            foreach (var tile in tiles)
            foreach (var player in players.GetEntities())
                if(player.target.value != tile.gridPosition.value)
                {
                    player.isPathDestroyed = true;
                    player.RemoveTarget();
                }
        }
    }
}