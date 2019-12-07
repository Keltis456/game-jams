using System;
using DeadBreach.ECS.Systems.Map;
using UnityEngine;

namespace DeadBreach.ECS.Systems
{
    public sealed class MapFeature : Feature
    {
        public MapFeature(GameContext game, GameObject mapTilePrefab, GameObject playerPrefab)
        {
            Add(new InitializeMapWithNewTiles(game));

            Add(new SetMapTileAsStartTile(game));
            Add(new SpawnPlayerOnTheStartTile(game));
            Add(new CreatePlayerFromPrefab(game, playerPrefab));
            
            Add(new CreateMapTileFromPrefab(game, mapTilePrefab));
            Add(new RenderTilesGridPositionToPosition(game));
            Add(new RenderNonTilesGridPositionToPosition(game));
            Add(new MarkTouchedImagesAsTarget(game));
            Add(new DebugTouchedImagesByColor(game));
        }
    }
}