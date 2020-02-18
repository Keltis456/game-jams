using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Map
{
    public class SpawnRandomObstacles : IInitializeSystem
    {
        private readonly GameContext game;
        private readonly IGroup<GameEntity> tiles;
        private readonly IGroup<GameEntity> obstacles;

        public SpawnRandomObstacles(GameContext game)
        {
            this.game = game;
            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Tile,
                    GameMatcher.GridPosition)
                .NoneOf(
                    GameMatcher.Obstacle,
                    GameMatcher.PathFinderObstacle));
            
            obstacles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PathFinderObstacle,
                    GameMatcher.GridPosition));
        }
        
        public void Initialize()
        {
            foreach (var tile in tiles.GetEntities())
            {
                if (Random.Range(0, 100) >= 10) continue;
                if (tile.gridPosition.value.IsAnyObstacle(obstacles.GetEntities())) continue;
                
                var obstacle = game.CreateEntity();              
                obstacle.isObstacle = true;
                obstacle.isPathFinderObstacle = true;
                obstacle.AddGridPosition(tile.gridPosition.value);
            }
        }
    }
}