using DeadBreach.ECS.Systems.PathFinding;

namespace DeadBreach.ECS.Systems
{
    public sealed class PathFindingFeature : Feature
    {
        public PathFindingFeature(GameContext game)
        {
            Add(new FindPathFromPlayerToTarget(game));

        }
    }
}