using UnityEngine;

namespace DeadBreach.ECS
{
	public class DeadBreachBootstrap : MonoBehaviour
    {
        public Canvas Canvas;
        public GameObject MapTilePrefab;

        private Entitas.Systems systems;

        private void Awake() => 
			systems = new DeadBreachSystems(
                Contexts.sharedInstance.game,
                Canvas,
                MapTilePrefab);

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
