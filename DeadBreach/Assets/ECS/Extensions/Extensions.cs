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

        public static void TestPathFinder()
        {
            new Vector2Int(0, 0).FindPathToTile(new Vector2Int(8, 8), GetAllTiles());
        }

        public static List<Vector2Int> FindPathToTile(this Vector2Int start, Vector2Int target, GameEntity[] tiles)
        {
            var result = new List<Vector2Int>();
            var cMap = FindWave(start, target);
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

        public static void AddAndSetupGameObject(this GameEntity entity, GameObject gameObject)
        {
            entity.AddId(entity.creationIndex);
            entity.AddGameObject(gameObject);

            entity.AddPosition(gameObject.transform.position);
            entity.AddRotation(gameObject.transform.rotation.eulerAngles);
            entity.AddScale(gameObject.transform.localScale);
        }

        private static int[,] FindWave(Vector2Int start, Vector2Int target)
        {
            var battlefield = new Vector2Int(9,9);

            var cMap = new int[battlefield.x, battlefield.y];
            int x, y, step = 0;
            for (x = 0; x < battlefield.x; x++)
            for (y = 0; y < battlefield.y; y++)
                cMap[x, y] = -1;

            cMap[target.x, target.y] = 0;
            while (true)
            {
                for (x = 0; x < battlefield.x; x++)
                for (y = 0; y < battlefield.y; y++)
                {
                    if (cMap[x, y] == step)
                    {
                        if (y - 1 >= 0 && cMap[x, y - 1] != -2 && cMap[x, y - 1] == -1)
                            cMap[x, y - 1] = step + 1;
                        if (x - 1 >= 0 && cMap[x - 1, y] != -2 && cMap[x - 1, y] == -1)
                            cMap[x - 1, y] = step + 1;
                        if (y + 1 < battlefield.y && cMap[x, y + 1] != -2 && cMap[x, y + 1] == -1)
                            cMap[x, y + 1] = step + 1;
                        if (x + 1 < battlefield.x && cMap[x + 1, y] != -2 && cMap[x + 1, y] == -1)
                            cMap[x + 1, y] = step + 1;
                    }
                }

                step++;
                if (cMap[start.x,start.y] > 0 || step > battlefield.x * battlefield.y)
                    break;
            }
            cMap.DebugLog();
            return cMap;
        }

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
