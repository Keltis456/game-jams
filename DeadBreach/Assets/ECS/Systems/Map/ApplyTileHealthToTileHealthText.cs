using Entitas;

namespace DeadBreach.ECS.Systems.Map
{
    public class ApplyTileHealthToTileHealthText : IExecuteSystem
    {
        private readonly GameContext game;
        private readonly IGroup<GameEntity> entities;

        public ApplyTileHealthToTileHealthText(GameContext game)
        {
            this.game = game;
            entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.TileHealth, GameMatcher.TileHealthLink));
        }

        public void Execute()
        {
            foreach (var entity in entities)
            {
                game.GetEntityWithId(entity.tileHealthLink.id)
                    .ReplaceText($"{entity.tileHealth.value}{(entity.hasTileMaxHealth ? $"/{entity.tileMaxHealth.value}" : "")}");
            }
        }
    }
}