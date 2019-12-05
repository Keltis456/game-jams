using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Map
{
    public class InitializeMapWithNewTiles : IInitializeSystem
    {
        private readonly GameContext game;

        public InitializeMapWithNewTiles(GameContext game) => 
            this.game = game;

        public void Initialize()
        {
            foreach (var cubicDirection in Extensions.Extensions.CubicDirections) 
                CreateNewTile(cubicDirection);
        }
        
        private void CreateNewTile(Vector3Int position)
        {
            var e = game.CreateEntity();
            e.isTile = true;
            e.AddCubicPosition(position);
        }
    }
}