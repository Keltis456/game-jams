using DeadBreach.ECS.Extensions;
using Entitas;

namespace DeadBreach.ECS.Systems.Map
{
    public class SetTouchedNeighborTileAsTarget : IExecuteSystem
    {
        private readonly IGroup<GameEntity> touchedTiles;
        private readonly IGroup<GameEntity> players;

        public SetTouchedNeighborTileAsTarget(GameContext game)
        {
            touchedTiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Tile,
                    GameMatcher.CubicPosition,
                    GameMatcher.Touched)
                .NoneOf(
                    GameMatcher.Player));
            
            players = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CubicPosition,
                    GameMatcher.Player));
        }

        public void Execute()
        {
            foreach (var touchedTile in touchedTiles)
            foreach (var player in players)
                if (player.cubicPosition.value.IsNeighborToTile(touchedTile.cubicPosition.value))
                    touchedTile.isTarget = true;
        }
    }
}