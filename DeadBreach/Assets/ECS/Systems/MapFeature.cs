using System;
using DeadBreach.ECS.Systems.Map;
using UnityEngine;

namespace DeadBreach.ECS.Systems
{
    public sealed class MapFeature : Feature
    {
        public MapFeature(GameContext game, Canvas canvas, GameObject mapTilePrefab)
        {
            Add(new InitializeMapWithNewTiles(game));

            Add(new CreateMapTileFromPrefab(game, canvas, mapTilePrefab));
            Add(new RenderGridPositionToPosition(game));
            Add(new DebugTouchedImagesByColor(game));
        }
    }
}