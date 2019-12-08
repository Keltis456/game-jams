using System;
using DeadBreach.ECS.Systems.Map;
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
            
            Add(new RemoveOldNonConfirmedTargetAndPlayerPathOnPointerEnter(game));
            Add(new MarkImagesUnderPointerAsPlayerTarget(game));
            
            //Add(new DebugTouchedImagesByColor(game));
        }
    }
}