using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Map
{
    public class DebugTouchedImagesByColor : IExecuteSystem
    {
        private readonly IGroup<GameEntity> tiles;

        public DebugTouchedImagesByColor(GameContext game)
        {
            tiles = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Touched, GameMatcher.Image));
        }

        public void Execute()
        {
            foreach (var tile in tiles) 
                tile.ReplaceImageColor(Color.green);
        }
    }
}