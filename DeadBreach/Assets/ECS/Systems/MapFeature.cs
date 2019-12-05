using System;
using DeadBreach.ECS.Systems.Map;
using UnityEngine;

namespace DeadBreach.ECS.Systems
{
    public sealed class MapFeature : Feature
    {
        public MapFeature(GameContext game, GameObject mapTilePrefab)
        {
            Add(new InitializeMapWithNewTiles(game));

            Add(new CreateMapTileFromPrefab(game, mapTilePrefab));
            Add(new RenderCubicPositionToTransform(game));
            Add(new ApplyTileNameToTileNameText(game));
            Add(new ApplyTileHealthToTileHealthText(game));
            Add(new ChangeTextActivenessIfEmpty(game));
            

            Add(new SetTouchedNeighborTileAsTarget(game));
            Add(new MoveTilesBehindPlayer(game));
            Add(new MovePlayerToTarget(game));
            Add(new DestroyTarget(game));
            Add(new DestroyTargetName(game));
            Add(new DestroyTargetHealth(game));
            Add(new DestroyTargetIcon(game));
        }
    }
}