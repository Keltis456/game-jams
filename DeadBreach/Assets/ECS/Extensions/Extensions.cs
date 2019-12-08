using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DeadBreach.ECS.Extensions
{
    public static class Extensions
    {
        private static GameContext Game => Contexts.sharedInstance.game;

        public static readonly Vector2Int[] GridDirections = {
            new Vector2Int(+0, +1), new Vector2Int(+1, +0),
            new Vector2Int(+0, -1), new Vector2Int(-1, +0)
        };
        
        public static bool IsNeighborToTile(this Vector2Int @this, Vector2Int target) => 
            GridDirections.Any(direction => @this + direction == target);

        public static GameEntity FindTileWithPosition(this IEnumerable<GameEntity> tiles, Vector2Int position) => 
            tiles
                .Where(tile => tile.hasGridPosition)
                .FirstOrDefault(tile => tile.gridPosition.value == position);
        
        public static void DebugLog(this int[,] array)
        {
            var output = "";
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    output += $"{array[i, j],3}";
                }

                output += "\n";
            }

            Debug.Log(output);
        }
        
        public static bool IsAnyObstacle(this Vector2Int tile, GameEntity[] obstacles) => 
            obstacles.Any(obstacle => obstacle.gridPosition.value == tile);

        public static List<Vector2Int> FindPathToTile(this Vector2Int start, Vector2Int target, GameEntity[] tiles, GameEntity[] obstacles, Vector2Int mapSize)
        {
            var result = new List<Vector2Int>();
            var cMap = FindWave(BuildObstacleMap(obstacles, mapSize), start, target);
            while (true)
            {
                var minValue = int.MaxValue;
                var tileWithMinValue = new Vector2Int(-9999, -9999);
                foreach (var neighborTile in GetNeighborTiles(start, tiles))
                {
                    var value = cMap[neighborTile.gridPosition.value.x, neighborTile.gridPosition.value.y];
                    if (value < minValue && value >= 0)
                    {
                        minValue = value;
                        tileWithMinValue = new Vector2Int(neighborTile.gridPosition.value.x, neighborTile.gridPosition.value.y);
                    }
                }

                if (tileWithMinValue == new Vector2Int(-9999, -9999)) return result;
                Debug.Log(tileWithMinValue);
                result.Add(tileWithMinValue);
                if (tileWithMinValue == target) return result;
                start = tileWithMinValue;
            }
        }

        public static void ReplaceAndSetupGameObject(this GameEntity entity, GameObject gameObject)
        {
            entity.ReplaceId(entity.creationIndex);
            entity.ReplaceGameObject(gameObject);

            entity.ReplacePosition(gameObject.transform.position);
            entity.ReplaceRotation(gameObject.transform.rotation.eulerAngles);
            entity.ReplaceScale(gameObject.transform.localScale);
        }

        private static int[,] FindWave(int[,] map, Vector2Int start, Vector2Int target)
        {
            var step = 0;
            for (var x = 0; x < map.GetLength(0); x++)
            for (var y = 0; y < map.GetLength(1); y++)
                if (map[x,y] != -2)
                    map[x, y] = -1;

            map[target.x, target.y] = 0;
            while (true)
            {
                for (var x = 0; x < map.GetLength(0); x++)
                for (var y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] != step) 
                        continue;
                    if (y - 1 >= 0 && map[x, y - 1] != -2 && map[x, y - 1] == -1)
                        map[x, y - 1] = step + 1;
                    if (x - 1 >= 0 && map[x - 1, y] != -2 && map[x - 1, y] == -1)
                        map[x - 1, y] = step + 1;
                    if (y + 1 < map.GetLength(1) && map[x, y + 1] != -2 && map[x, y + 1] == -1)
                        map[x, y + 1] = step + 1;
                    if (x + 1 < map.GetLength(0) && map[x + 1, y] != -2 && map[x + 1, y] == -1)
                        map[x + 1, y] = step + 1;
                }

                step++;
                if (map[start.x,start.y] > 0 || step > map.GetLength(0) * map.GetLength(1))
                    break;
            }
            map.DebugLog();
            return map;
        }

        private static int[,] BuildObstacleMap(GameEntity[] obstacles, Vector2Int mapSize)
        {
            var result = new int[mapSize.x, mapSize.y];

            foreach (var obstacle in obstacles)
            {
                var position = obstacle.gridPosition.value;
                result[position.x, position.y] = -2;
            }

            return result;
        }

        private static GameEntity[] GetAllTiles()
        {
            return Game
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
