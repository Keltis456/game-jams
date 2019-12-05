using DeadBreach.ECS.Extensions;
using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Map
{
    public class MoveTilesBehindPlayer : IExecuteSystem
    {
        private readonly GameContext game;
        private readonly IGroup<GameEntity> tiles;
        private readonly IGroup<GameEntity> targets;
        private readonly IGroup<GameEntity> players;

        public MoveTilesBehindPlayer(GameContext game)
        {
            this.game = game;
            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Tile,
                    GameMatcher.CubicPosition)
                .NoneOf(
                    GameMatcher.Player));

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
            foreach (var target in targets)
            foreach (var player in players)
            {
                var targetPosition = target.cubicPosition.value;
                var playerPosition = player.cubicPosition.value;
                var direction = targetPosition - playerPosition;

                if (playerPosition == Vector3Int.zero)
                {
                    MoveTileFromBehind(playerPosition, direction);
                    CreateNewTile(playerPosition - direction);
                }
                else if (targetPosition == Vector3Int.zero)
                {
                    var fakedDirection = direction.CubicRotateCounterClockwise().CubicRotateCounterClockwise();

                    MoveTileFromBehind(playerPosition, fakedDirection);
                    CreateNewTile(playerPosition - fakedDirection);
                }
                else if (targetPosition == playerPosition.CubicRotateClockwise())
                {
                    var fakedDirection = direction.CubicRotateCounterClockwise();

                    MoveTileFromBehind(playerPosition, fakedDirection);
                    CreateNewTile(playerPosition - fakedDirection);
                }
                else if (targetPosition == playerPosition.CubicRotateCounterClockwise())
                {
                    var fakedDirection = direction.CubicRotateClockwise();

                    MoveTileFromBehind(playerPosition, fakedDirection);
                    CreateNewTile(playerPosition - fakedDirection);
                }
            }
        }

        private void CreateNewTile(Vector3Int position)
        {
            var e = game.CreateEntity();
            e.isTile = true;
            e.AddCubicPosition(position);
        }

        private void MoveTileFromBehind(Vector3Int currentTilePosition, Vector3Int direction) => 
            tiles.GetEntities().FindTileWithPosition(currentTilePosition - direction)
                ?.ReplaceCubicPosition(currentTilePosition);
    }
}