using System.Linq;
using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Movement
{
    public class MoveAgentToNextConfirmedPathPoint : IExecuteSystem
    {
        private readonly GameContext game;
        private readonly IGroup<GameEntity> agents;
        private readonly IGroup<GameEntity> tiles;

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
            
            tiles = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Tile, 
                    GameMatcher.GridPosition));
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
                
                foreach (var tile in tiles)
                    if (tile.gridPosition.value == agent.gridPosition.value)
                        tile.isDestroyedTile = true;
            }
        }
    }
}