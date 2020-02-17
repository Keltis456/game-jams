using DeadBreach.ECS.Systems.Movement;

namespace DeadBreach.ECS.Systems
{
    public sealed class MovementFeature : Feature
    {
        public MovementFeature(GameContext game)
        {
            Add(new MoveAgentToNextConfirmedPathPoint(game));
        }
    }
}