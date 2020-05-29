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
            GameObject mapTilePrefab,
            Sprite mapTile, Sprite pathTile, Sprite pathTileEndPrefab, 
            GameObject playerPrefab,
            GameObject obstaclePrefab)
        {
            Add(new ScreenFeature(game, canvas));
            
            Add(new TouchFeature(game));

            Add(new MapFeature(game, mapTilePrefab,mapTile, pathTile, pathTileEndPrefab, playerPrefab, obstaclePrefab));
            Add(new PathFindingFeature(game));
            Add(new MovementFeature(game));

            Add(new SkillFeature(game));


            Add(new RenderFeature(game));
            Add(new DoTweenFeature(game));
            Add(new AnimatorFeature(game));
            Add(new TextFeature(game));

            Add(new DestroyFeature(game));
        }
	}
}
