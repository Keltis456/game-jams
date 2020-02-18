using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Map
{
    public class CreateObstacleFromPrefab : IExecuteSystem
    {
        private readonly GameObject obstaclePrefab;
        private readonly IGroup<GameEntity> obstacles;

        public CreateObstacleFromPrefab(GameContext game, GameObject obstaclePrefab)
        {
            this.obstaclePrefab = obstaclePrefab;
            obstacles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Obstacle)
                .NoneOf(
                    GameMatcher.GameObject));
        }

        public void Execute()
        {
            foreach (var obstacle in obstacles.GetEntities())
            {
                obstacle.ReplaceAndSetupGameObject(Object.Instantiate(obstaclePrefab, Vector3.zero, Quaternion.identity));
                obstacle.isPathFinderObstacle = true;
            }
        }
    }
}