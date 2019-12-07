using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Map
{
    public class MarkTouchedImagesAsTarget : IExecuteSystem
    {
        private readonly IGroup<GameEntity> tiles;

        public MarkTouchedImagesAsTarget(GameContext game)
        {
            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Touched,
                    GameMatcher.Image)
                .NoneOf(
                    GameMatcher.Target));
        }

        public void Execute()
        {
            foreach (var tile in tiles.GetEntities()) 
                tile.isTarget = true;
        }
    }
}