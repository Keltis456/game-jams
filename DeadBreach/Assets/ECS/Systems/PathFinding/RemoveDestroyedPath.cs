using Entitas;

namespace DeadBreach.ECS.Systems.PathFinding
{
    public class RemoveDestroyedPath : IExecuteSystem
    {
        private readonly IGroup<GameEntity> agents;

        public RemoveDestroyedPath(GameContext game)
        {
            agents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PathFinderAgent,
                    GameMatcher.PathFinderPath,
                    GameMatcher.PathDestroyed));
        }

        public void Execute()
        {
            foreach (var agent in agents.GetEntities())
            {
                agent.isPathDestroyed = false;
                agent.RemovePathFinderPath();
            }
        }
    }
}