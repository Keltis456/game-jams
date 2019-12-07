using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Map
{
    public class RenderNonTilesGridPositionToPosition : IExecuteSystem
    {
        private readonly GameContext game;
        private readonly IGroup<GameEntity> entities;

        public RenderNonTilesGridPositionToPosition(GameContext game)
        {
            this.game = game;
            entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.GridPosition,
                    GameMatcher.Position)
                .NoneOf(GameMatcher.Tile));
        }

        public void Execute()
        {
            foreach (var entity in entities)
            {
                var position = game.mainCanvas.value.transform.position;
                entity.ReplacePosition(new Vector3(entity.gridPosition.value.x + position.x, 0, entity.gridPosition.value.y + position.z));
            }
        }
    }
}