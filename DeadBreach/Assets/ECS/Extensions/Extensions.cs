using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DeadBreach.ECS.Extensions
{
    public static class Extensions
    {
        public static readonly Vector2Int[] GridDirections = {
            new Vector2Int(+1, 0), new Vector2Int(0, +1),
            new Vector2Int(-1, 0), new Vector2Int(0, -1)
        };
        
        public static bool IsNeighborToTile(this Vector2Int @this, Vector2Int target) => 
            GridDirections.Any(direction => @this + direction == target);

        public static GameEntity FindTileWithPosition(this IEnumerable<GameEntity> tiles, Vector2Int position) => 
            tiles
                .Where(tile => tile.hasGridPosition)
                .FirstOrDefault(tile => tile.gridPosition.value == position);

        public static void TestPathFinder()
        {
            foreach (var tile in new Vector2Int().FindPathToTile(new Vector2Int(0, 8)))
                Debug.Log($"{tile.x} : {tile.y}");
        }

        public static List<Vector2Int> FindPathToTile(this Vector2Int @this, Vector2Int target, List<Vector2Int> previousResult = null, GameEntity[] allTiles = null)
        {
            var result = previousResult ?? new List<Vector2Int>();

            var tiles = allTiles ?? GetAllTiles();

            var neighborTiles = GetNeighborTiles(@this, tiles);
            foreach (var resultTile in result) 
                neighborTiles.Remove(neighborTiles.FindTileWithPosition(resultTile));

            foreach (var neighborTile in neighborTiles)
            {
                if (neighborTile.gridPosition.value == target)
                {
                    result.Add(neighborTile.gridPosition.value);
                    return result;
                }
                else
                {
                    result.Add(neighborTile.gridPosition.value);
                    return neighborTile.gridPosition.value.FindPathToTile(target, result, tiles);
                }
            }

            return null;
        }

        private static GameEntity[] GetAllTiles()
        {
            return Contexts.sharedInstance.game
                .GetGroup(GameMatcher
                    .AllOf(GameMatcher.Tile, GameMatcher.GridPosition))
                .GetEntities();
        }

        private static List<GameEntity> GetNeighborTiles(Vector2Int @this, GameEntity[] tiles)
        {
            var neighborTiles =
                GridDirections
                    .Select(gridDirection => tiles.FindTileWithPosition(@this + gridDirection))
                    .Where(tile => tile != null)
                    .ToList();
            return neighborTiles;
        }
    }
}
