using System;
using System.Linq;
using DeadBreach.ECS.Systems;
using Entitas;
using UnityEngine;

namespace DeadBreach.ECS
{
	public sealed class DeadBreachSystems : Feature
	{
        public DeadBreachSystems(
            GameContext game, 
            Canvas canvas, 
            GameObject mapTilePrefab, GameObject pathTilePrefab, GameObject pathTileEndPrefab, 
            GameObject playerPrefab)
        {
            Add(new ScreenFeature(game, canvas));
            
            Add(new TouchFeature(game));

            Add(new MapFeature(game, mapTilePrefab, pathTilePrefab, pathTileEndPrefab, playerPrefab));
            Add(new PathFindingFeature(game));
            Add(new MovementFeature(game));


            Add(new RenderFeature(game));
            Add(new DoTweenFeature(game));
            Add(new AnimatorFeature(game));
            Add(new TextFeature(game));

            Add(new DestroyFeature(game));
        }
	}

    public class MoveAgentToNextConfirmedPathPoint : IExecuteSystem
    {
        private readonly GameContext game;
        private readonly IGroup<GameEntity> agents;

        public MoveAgentToNextConfirmedPathPoint(GameContext game)
        {
            this.game = game;
            agents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PathFinderAgent,
                    GameMatcher.PathFinderPath,
                    GameMatcher.PathFinderPathConfirmed,
                    GameMatcher.Target)
                .NoneOf(
                    GameMatcher.TweenPlaying));
        }

        public void Execute()
        {
            foreach (var agent in agents.GetEntities())
            {
                var path = agent.pathFinderPath.value;
                if (agent.gridPosition.value == path.Last())
                {
                    agent.isPathDestroyed = true;
                    agent.isPathFinderPathConfirmed = false;
                    agent.RemoveTarget();
                    continue;
                }

                Vector2Int nextNode;
                var i = path.IndexOf(agent.gridPosition.value);
                //if (i == -1) 
                //    i = 0;
                if (i + 1 < path.Count)
                    nextNode = path[i + 1];
                else
                    continue;

                agent.AddTweenMove(
                    new TweenTransform(
                        nextNode.GridToWorld(game.mainCanvas.value.transform.position), 
                        new Vector3(agent.rotation.value.x, agent.gridPosition.value.RotationToTile(nextNode), agent.rotation.value.z), 
                        agent.scale.value));
                agent.ReplaceGridPosition(nextNode);
            }
        }
    }
}
