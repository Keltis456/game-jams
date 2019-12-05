using UnityEngine;

namespace DeadBreach.ECS
{
	public class DeadBreachBootstrap : MonoBehaviour
    {
        public GameObject MapTilePrefab; //TODO: Initialize array of mapTilePrefabs as settings context entities 

        private Entitas.Systems systems;

        private void Awake() => 
			systems = new DeadBreachSystems(
                Contexts.sharedInstance.game,
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
