using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Map
{
    public class RenderTilesGridPositionToPosition : IExecuteSystem
    {
        private readonly IGroup<GameEntity> entities;

        public RenderTilesGridPositionToPosition(GameContext game)
        {
            entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.GridPosition,
                    GameMatcher.Position,
                    GameMatcher.Tile));
        }

        public void Execute()
        {
            foreach (var entity in entities)
                entity.ReplacePosition(new Vector3(entity.gridPosition.value.x, entity.gridPosition.value.y, 0));
        }
    }
}