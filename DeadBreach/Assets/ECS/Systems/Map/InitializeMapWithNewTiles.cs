using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Map
{
    public class InitializeMapWithNewTiles : IInitializeSystem
    {
        public const int SizeX = 9;
        public const int SizeY = 9;

        private readonly GameContext game;

        public InitializeMapWithNewTiles(GameContext game) => 
            this.game = game;

        public void Initialize()
        {
            for (var i = 0; i < SizeX; i++)
            for (var j = 0; j < SizeY; j++)
                CreateNewTile(new Vector2Int(i, j));
        }
        
        private void CreateNewTile(Vector2Int position)
        {
            var entity = game.CreateEntity();
            entity.isTile = true;
            entity.AddGridPosition(position);
        }
    }
}