using System;
using System.Collections;
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
            string output = "";
            var wave = FindWave(new Vector2Int(0, 0), 8, 8);
            for (int i = 0; i < wave.GetLength(0); i++)
            {
                for (int j = 0; j < wave.GetLength(1); j++)
                {
                    output += $"{wave[i, j],3}";
                }

                output += "\n";
            }
            Debug.Log(output);
            Move(wave, new Vector2Int(0, 0), new Vector2Int(8, 8));

            //foreach (var tile in new Vector2Int().FindPathToTile(new Vector2Int(0, 8)))
            //    Debug.Log($"{tile.x} : {tile.y}");
        }

        private static void Move(int[,] cMap, Vector2Int start, Vector2Int target)
        {
            var minValue = int.MaxValue;
            Vector2Int tileWithMinValue = new Vector2Int(-9999, -9999);
            foreach (var neighborTile in GetNeighborTiles(start, GetAllTiles()))
            {
                var value = cMap[neighborTile.gridPosition.value.x, neighborTile.gridPosition.value.y];
                if (value < minValue && value >= 0)
                {
                    minValue = value;
                    tileWithMinValue = new Vector2Int(neighborTile.gridPosition.value.x, neighborTile.gridPosition.value.y);
                }
            }

            if (tileWithMinValue != new Vector2Int(-9999, -9999))
            {
                Debug.Log($"{tileWithMinValue.x} : {tileWithMinValue.y}");
                if (tileWithMinValue != target)
                {
                    Move(cMap, tileWithMinValue, target);
                }
            }
        }

        public static int[,] FindWave(Vector2Int start, int targetX, int targetY)
        {
            var battlefield = new Vector2Int(9,9);

            bool add = true; // условие выхода из цикла
            // делаем копию карты локации, для дальнейшей ее разметки
            var cMap = new int[battlefield.x, battlefield.y];
            int x, y, step = 0; // значение шага равно 0
            for (x = 0; x < battlefield.x; x++)
            for (y = 0; y < battlefield.y; y++)
            {
                cMap[x, y] = -1; //иначе еще не ступали сюда
            }

            //начинаем отсчет с финиша, так будет удобней востанавливать путь
            cMap[targetX, targetY] = 0;
            while (add == true)
            {
                add = false;
                for (x = 0; x < battlefield.x; x++)
                for (y = 0; y < battlefield.y; y++)
                {
                    if (cMap[x, y] == step)
                    {
                        // если соседняя клетка не стена, и если она еще не помечена
                        // то помечаем ее значением шага + 1
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
                add = true;
                if (cMap[start.x,start.y] > 0) //решение найдено
                    add = false;
                if (step > battlefield.x * battlefield.y) //решение не найдено, если шагов больше чем клеток
                    add = false;
            }

            return cMap; // возвращаем помеченную матрицу, для востановления пути в методе move()
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
