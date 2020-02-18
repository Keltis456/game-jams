using System;
using DeadBreach.ECS.Systems.Map;
using UnityEngine;

namespace DeadBreach.ECS.Systems
{
    public sealed class MapFeature : Feature
    {
        public MapFeature(GameContext game, GameObject mapTilePrefab,Sprite mapTile, Sprite pathTile, Sprite pathTileEnd, GameObject playerPrefab)
        {
            Add(new InitializeMapWithNewTiles(game));

            Add(new SetMapTileAsStartTile(game));
            Add(new SpawnPlayerOnTheStartTile(game));
            
            Add(new CreatePlayerFromPrefab(game, playerPrefab));
            Add(new SetTileSprite(game, mapTile));
            Add(new SetPathTileSprite(game, pathTile));
            Add(new SetPathEndTileSprite(game, pathTileEnd));
            Add(new CreateMapTileFromPrefab(game, mapTilePrefab));

            Add(new RenderTilesGridPositionToPosition(game));
            Add(new RenderNonTilesGridPositionToPosition(game));
            
            Add(new SetTouchedPlayerTargetAsConfirmedPath(game));
            Add(new RemoveOldNonConfirmedTargetAndPlayerPathOnPointerEnter(game));
            Add(new MarkImagesUnderPointerAsPlayerTarget(game));
        }
    }
}