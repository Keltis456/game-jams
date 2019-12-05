using DeadBreach.ECS.Systems;
using Entitas;
using UnityEngine;

namespace DeadBreach.ECS
{
	public sealed class DeadBreachSystems : Feature
	{
        public DeadBreachSystems(GameContext game, Canvas canvas, GameObject mapTilePrefab)
        {
            Add(new ScreenFeature(game, canvas));
            
            Add(new TouchFeature(game));

            Add(new MapFeature(game, canvas, mapTilePrefab));
            Add(new PathFindingFeature(game));

            Add(new AnimatorFeature(game));
            Add(new TextFeature(game));
            Add(new RenderFeature(game));

            Add(new DestroyFeature(game));
        }
	}

    public class PathFindingFeature : Feature
    {
        public PathFindingFeature(GameContext game)
        {
            //Взять старт
            //Взять конец
            //Взять ближайшие точки
            //
        }
    }
}
