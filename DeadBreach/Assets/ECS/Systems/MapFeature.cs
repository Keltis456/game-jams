using System;
using DeadBreach.ECS.Systems.Map;
using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems
{
    public sealed class MapFeature : Feature
    {
        public MapFeature(GameContext game, GameObject mapTilePrefab, GameObject pathTilePrefab, GameObject pathTileEndPrefab, GameObject playerPrefab)
        {
            Add(new InitializeMapWithNewTiles(game));

            Add(new SetMapTileAsStartTile(game));
            Add(new SpawnPlayerOnTheStartTile(game));
            
            Add(new CreatePlayerFromPrefab(game, playerPrefab));
            Add(new CreatePathTileFromPrefab(game, pathTilePrefab));
            Add(new CreatePathEndTileFromPrefab(game, pathTileEndPrefab));
            Add(new CreateMapTileFromPrefab(game, mapTilePrefab));

            Add(new RenderTilesGridPositionToPosition(game));
            Add(new RenderNonTilesGridPositionToPosition(game));
            
            //if touched == target -> move to target
            //else -> remove target
            
            Add(new RemoveOldNonConfirmedTargetAndPlayerPathOnTouch(game));
            Add(new MarkTouchedImagesAsPlayerTarget(game));
            
            //Add(new DebugTouchedImagesByColor(game));
        }
    }

    public class RemoveOldNonConfirmedTargetAndPlayerPathOnTouch : IExecuteSystem
    {
        private readonly IGroup<GameEntity> tiles;
        private readonly IGroup<GameEntity> players;

        public RemoveOldNonConfirmedTargetAndPlayerPathOnTouch(GameContext game)
        {
            players = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.Target,
                    GameMatcher.PathFinderPath));

            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Touched,
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