using System;
using DeadBreach.ECS.Systems;
using UnityEngine;

namespace DeadBreach.ECS
{
	public sealed class DeadBreachSystems : Feature
	{
        public DeadBreachSystems(
            GameContext game, 
            Canvas canvas, 
            GameObject mapTilePrefab, GameObject pathTilePrefab, GameObject pathTileEndPrefab, 
            GameObject playerPrefab)
        {
            Add(new ScreenFeature(game, canvas));
            
            Add(new TouchFeature(game));

            Add(new MapFeature(game, mapTilePrefab, pathTilePrefab, pathTileEndPrefab, playerPrefab));
            Add(new PathFindingFeature(game));
            Add(new MovementFeature(game));


            Add(new RenderFeature(game));
            Add(new DoTweenFeature(game));
            Add(new AnimatorFeature(game));
            Add(new TextFeature(game));

            Add(new DestroyFeature(game));
        }
	}
}
