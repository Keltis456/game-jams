using System;
using DeadBreach.ECS.Systems.Render;

namespace DeadBreach.ECS.Systems
{
	public sealed class RenderFeature : Feature
	{
		public RenderFeature(GameContext game)
		{
			Add(new RenderRotation(game));
			Add(new RenderPosition(game));
			Add(new RenderScale(game));

			Add(new RenderImageColor(game));
        }
	}
}
