using UnityEngine;
using UnityEngine.Serialization;

namespace DeadBreach.ECS
{
	public class DeadBreachBootstrap : MonoBehaviour
    {
        public Canvas Canvas;
        public GameObject MapTilePrefab;
        public Sprite MapTile;
        public Sprite PathTile;
        public Sprite PathTileEndPrefab;
        public GameObject PlayerPrefab;
        public GameObject ObstaclePrefab;

        private Entitas.Systems systems;

        private void Awake() => 
			systems = new DeadBreachSystems(
                Contexts.sharedInstance.game,
                Canvas,
                MapTilePrefab,
                MapTile,
                PathTile,
                PathTileEndPrefab,
                PlayerPrefab, 
                ObstaclePrefab);

		private void Start() => 
			systems.Initialize();

		private void Update()
		{
			systems.Execute();
			systems.Cleanup();
		}

		private void OnDestroy() => 
			systems.TearDown();
	}
}
