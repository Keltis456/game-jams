using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Map
{
    public class MarkImagesUnderPointerAsPlayerTarget : IExecuteSystem
    {
        private readonly IGroup<GameEntity> tiles;
        private readonly IGroup<GameEntity> players;

        public MarkImagesUnderPointerAsPlayerTarget(GameContext game)
        {
            players = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.GridPosition)
                .NoneOf(
                    GameMatcher.Target));

            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PointerEnter,
                    GameMatcher.Image,
                    GameMatcher.GridPosition));
        }

        public void Execute()
        {
            foreach (var tile in tiles)
            foreach (var player in players.GetEntities())
                if(tile.gridPosition.value != player.gridPosition.value)
                    player.AddTarget(tile.gridPosition.value);
        }
    }
}