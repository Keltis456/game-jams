using Entitas;

namespace DeadBreach.ECS.Systems.Render
{
	public class RenderPosition : IExecuteSystem
	{
        private readonly IGroup<GameEntity> entities;

        public RenderPosition(GameContext game) =>
            entities = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.GameObject,
                        GameMatcher.Position)
                    .NoneOf(
                        GameMatcher.TweenPlaying));

        public void Execute()
        {
			foreach (var entity in entities)
                entity.gameObject.value.transform.localPosition = entity.position.value;
        }
    }
}
