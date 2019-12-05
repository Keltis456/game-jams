using DeadBreach.ECS.Systems;
using UnityEngine;

namespace DeadBreach.ECS
{
	public sealed class DeadBreachSystems : Feature
	{
        public DeadBreachSystems(GameContext game, GameObject mapTilePrefab)
        {
            Add(new ScreenFeature(game));
            
            Add(new TouchFeature(game));
            //Add(new MapFeature(game, mapTilePrefab));


            Add(new AnimatorFeature(game));
            Add(new TextFeature(game));
            Add(new RenderFeature(game));

            Add(new DestroyFeature(game));
        }
	}
}
