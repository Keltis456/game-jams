using Entitas;

namespace DeadBreach.ECS.Systems.Render
{
	public class RenderScale : IExecuteSystem
	{
        private readonly IGroup<GameEntity> entities;

        public RenderScale(GameContext game) =>
            entities = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.GameObject, 
                        GameMatcher.Scale)
                    .NoneOf(
                        GameMatcher.TweenPlaying));

        public void Execute()
        {
            foreach (var entity in entities)
                entity.gameObject.value.transform.localScale = entity.scale.value;
        }
    }
}
