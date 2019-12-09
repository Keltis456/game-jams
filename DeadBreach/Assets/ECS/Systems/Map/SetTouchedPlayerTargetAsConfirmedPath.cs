using Entitas;

namespace DeadBreach.ECS.Systems.Map
{
    public class SetTouchedPlayerTargetAsConfirmedPath : IExecuteSystem
    {
        private readonly IGroup<GameEntity> tiles;
        private readonly IGroup<GameEntity> players;

        public SetTouchedPlayerTargetAsConfirmedPath(GameContext game)
        {
            players = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.Target,
                    GameMatcher.PathFinderPath)
                .NoneOf(
                    GameMatcher.PathFinderPathConfirmed));

            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Touched,
                    GameMatcher.Image));
        }

        public void Execute()
        {
            foreach (var tile in tiles)
            foreach (var player in players.GetEntities())
                if(player.target.value == tile.gridPosition.value)
                {
                    player.isPathFinderPathConfirmed = true;
                }
        }
    }
}