using System;
using DeadBreach.ECS.Systems.PathFinding;

namespace DeadBreach.ECS.Systems
{
    public sealed class PathFindingFeature : Feature
    {
        public PathFindingFeature(GameContext game)
        {
            Add(new RemoveDestroyedPathTiles(game));
            Add(new RemoveDestroyedPathEndTiles(game));
            Add(new RemoveDestroyedPath(game));

            Add(new FindPathFromAgentToTarget(game));

            Add(new SetPathTiles(game));
            Add(new SetPathEndTiles(game));

            Add(new UnMarkDestroyedTiles(game));

        }
    }
}