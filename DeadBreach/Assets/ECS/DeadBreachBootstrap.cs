using UnityEngine;

namespace DeadBreach.ECS
{
	public class DeadBreachBootstrap : MonoBehaviour
    {
        public Canvas Canvas;
        public GameObject MapTilePrefab;
        public GameObject PathTilePrefab;
        public GameObject PathTileEndPrefab;
        public GameObject PLayerPrefab;

        private Entitas.Systems systems;

        private void Awake() => 
			systems = new DeadBreachSystems(
                Contexts.sharedInstance.game,
                Canvas,
                MapTilePrefab,
                PathTilePrefab,
                PathTileEndPrefab,
                PLayerPrefab);

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
