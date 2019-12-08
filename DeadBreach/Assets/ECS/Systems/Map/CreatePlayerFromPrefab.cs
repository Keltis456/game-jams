using DeadBreach.ECS.Extensions;
using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Map
{
    public class CreatePlayerFromPrefab : IExecuteSystem
    {
        private readonly GameObject playerPrefab;
        private readonly IGroup<GameEntity> players;

        public CreatePlayerFromPrefab(GameContext game, GameObject playerPrefab)
        {
            this.playerPrefab = playerPrefab;
            players = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Player)
                .NoneOf(GameMatcher.GameObject));
        }

        public void Execute()
        {
            foreach (var player in players.GetEntities()) 
                player.ReplaceAndSetupGameObject(Object.Instantiate(playerPrefab));
        }
    }
}