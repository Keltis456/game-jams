using DeadBreach.ECS.Extensions;
using Entitas;

namespace DeadBreach.ECS.Systems.PathFinding
{
    public class FindPathFromAgentToTarget : IExecuteSystem
    {
        private readonly IGroup<GameEntity> agents;
        private readonly IGroup<GameEntity> tiles;

        public FindPathFromAgentToTarget(GameContext game)
        {
            agents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PathFinderAgent,
                    GameMatcher.GridPosition,
                    GameMatcher.Target)
                .NoneOf(
                    GameMatcher.PathFinderPath));

            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Tile, 
                    GameMatcher.GridPosition));
        }

        public void Execute()
        {
            foreach (var agent in agents.GetEntities())
            {
                var path = agent.gridPosition.value.FindPathToTile(agent.target.value, tiles.GetEntities());
                if (path != null && path.Count > 0) 
                    agent.AddPathFinderPath(path);
            }
        }
    }
}