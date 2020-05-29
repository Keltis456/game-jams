using DeadBreach.ECS.Skills;
using Entitas;

namespace DeadBreach.ECS.Systems.Map
{
    public class SpawnPlayerOnTheStartTile : IInitializeSystem
    {
        private readonly GameContext game;
        private readonly IGroup<GameEntity> players;
        private readonly IGroup<GameEntity> startTiles;

        public SpawnPlayerOnTheStartTile(GameContext game)
        {
            this.game = game;
            startTiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.StartTile, 
                    GameMatcher.GridPosition));
        }
        public void Initialize()
        {
            foreach (var startTile in startTiles)
            {
                var player = game.CreateEntity();
                player.isPlayer = true;
                player.isPathFinderAgent = true;
                player.isPathFinderObstacle = true;
                player.AddGridPosition(startTile.gridPosition.value);
                
                player.AddRequireSkillOnSlot(new SkillSword(), 0);
            }
        }
    }
}