namespace DeadBreach.ECS.Systems
{
    public class MovementFeature : Feature
    {
        public MovementFeature(GameContext game)
        {
            Add(new MoveAgentToNextConfirmedPathPoint(game));
        }
    }
}