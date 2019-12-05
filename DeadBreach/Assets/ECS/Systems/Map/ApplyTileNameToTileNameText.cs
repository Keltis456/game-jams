using Entitas;

namespace DeadBreach.ECS.Systems.Map
{
    public class ApplyTileNameToTileNameText : IExecuteSystem
    {
        private readonly GameContext game;
        private readonly IGroup<GameEntity> entities;

        public ApplyTileNameToTileNameText(GameContext game)
        {
            this.game = game;
            entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.TileName, GameMatcher.TileNameLink));
        }

        public void Execute()
        {
            foreach (var entity in entities)
                game.GetEntityWithId(entity.tileNameLink.id).ReplaceText(entity.tileName.value);
        }
    }
}