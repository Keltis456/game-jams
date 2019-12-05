using System.Linq;
using UnityEngine;

namespace DeadBreach.ECS.Extensions
{
    public static class Extensions
    {
        public static readonly Vector3Int[] GridDirections = {
            new Vector3Int(+1, 0, 0), new Vector3Int(0, +1, 0),
            new Vector3Int(-1, 0, 0), new Vector3Int(0, -1, 0)
        };
        
        public static bool IsNeighborToTile(this Vector3Int @this, Vector3Int target) => 
            GridDirections.Any(direction => @this + direction == target);

        public static GameEntity FindTileWithPosition(this GameEntity[] tiles, Vector3Int position) => 
            tiles
                .Where(tile => tile.hasGridPosition)
                .FirstOrDefault(tile => tile.gridPosition.value == position);

        public static Vector3Int CubicRotateClockwise(this Vector3Int @this) => 
            new Vector3Int(-@this.z, -@this.x, -@this.y);

        public static Vector3Int CubicRotateCounterClockwise(this Vector3Int @this) => 
            new Vector3Int(-@this.y, -@this.z, -@this.x);
    }
}
