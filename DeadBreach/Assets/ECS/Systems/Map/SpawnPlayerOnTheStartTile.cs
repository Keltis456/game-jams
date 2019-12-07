using Entitas;

namespace DeadBreach.ECS.Systems.Map
{
    public class SpawnPlayerOnTheStartTile : IExecuteSystem
    {
        private readonly GameContext game;
        private readonly IGroup<GameEntity> players;
        private readonly IGroup<GameEntity> startTiles;

        public SpawnPlayerOnTheStartTile(GameContext game)
        {
            this.game = game;
            players = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Player));
            startTiles = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.StartTile, GameMatcher.GridPosition));
        }

        public void Execute()
        {
            foreach (var startTile in startTiles)
            {
                if (players.count <= 0)
                {
                    var player = game.CreateEntity();
                    player.isPlayer = true;
                    player.isPathFinderAgent = true;
                    player.AddGridPosition(startTile.gridPosition.value);
                }
            }
        }
    }
}