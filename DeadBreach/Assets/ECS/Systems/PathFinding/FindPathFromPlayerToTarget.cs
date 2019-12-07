using DeadBreach.ECS.Extensions;
using Entitas;

namespace DeadBreach.ECS.Systems.PathFinding
{
    public class FindPathFromPlayerToTarget : IExecuteSystem
    {
        private readonly IGroup<GameEntity> targets;
        private readonly IGroup<GameEntity> agents;
        private readonly IGroup<GameEntity> tiles;

        public FindPathFromPlayerToTarget(GameContext game)
        {
            targets = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Target,
                    GameMatcher.GridPosition));

            agents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PathFinderAgent,
                    GameMatcher.GridPosition)
                .NoneOf(
                    GameMatcher.PathFinderPath));

            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Tile, 
                    GameMatcher.GridPosition));
        }

        public void Execute()
        {
            foreach (var target in targets)
            foreach (var agent in agents.GetEntities())
            {
                var path = agent.gridPosition.value.FindPathToTile(target.gridPosition.value, tiles.GetEntities());
                if (path != null && path.Count > 0) 
                    agent.AddPathFinderPath(path);
            }
        }
    }
}