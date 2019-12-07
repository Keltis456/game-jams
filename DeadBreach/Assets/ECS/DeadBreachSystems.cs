using DeadBreach.ECS.Systems;
using UnityEngine;

namespace DeadBreach.ECS
{
	public sealed class DeadBreachSystems : Feature
	{
        public DeadBreachSystems(GameContext game, Canvas canvas, GameObject mapTilePrefab, GameObject playerPrefab)
        {
            Add(new ScreenFeature(game, canvas));
            
            Add(new TouchFeature(game));

            Add(new MapFeature(game, mapTilePrefab, playerPrefab));
            Add(new PathFindingFeature(game));

            Add(new AnimatorFeature(game));
            Add(new TextFeature(game));
            Add(new RenderFeature(game));

            Add(new DestroyFeature(game));
        }
	}
}
