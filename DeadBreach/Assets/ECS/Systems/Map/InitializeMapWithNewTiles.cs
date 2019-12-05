using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Map
{
    public class InitializeMapWithNewTiles : IInitializeSystem
    {
        private const int SizeX = 10;
        private const int SizeY = 10;

        private readonly GameContext game;

        public InitializeMapWithNewTiles(GameContext game) => 
            this.game = game;

        public void Initialize()
        {
            for (var i = 0; i < SizeX; i++)
            {
                for (var j = 0; j < SizeY; j++)
                {
                    CreateNewTile(new Vector3Int(i,j,0));
                }
            }
        }
        
        private void CreateNewTile(Vector3Int position)
        {
            var e = game.CreateEntity();
            e.isTile = true;
            e.AddGridPosition(position);
        }
    }
}