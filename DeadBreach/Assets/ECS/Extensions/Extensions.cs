using System.Linq;
using UnityEngine;

namespace DeadBreach.ECS.Extensions
{
    public static class Extensions
    {
        public static readonly Vector3Int[] CubicDirections = {
            new Vector3Int(+1, -1, 0), new Vector3Int(+1, 0, -1), new Vector3Int(0, +1, -1),
            new Vector3Int(-1, +1, 0), new Vector3Int(-1, 0, +1), new Vector3Int(0, -1, +1)
        };
        
        public static bool IsNeighborToTile(this Vector3Int @this, Vector3Int target) => 
            CubicDirections.Any(direction => @this + direction == target);

        public static GameEntity FindTileWithPosition(this GameEntity[] tiles, Vector3Int position) => 
            tiles
                .Where(tile => tile.hasCubicPosition)
                .FirstOrDefault(tile => tile.cubicPosition.value == position);

        public static Vector3Int CubicRotateClockwise(this Vector3Int @this) => 
            new Vector3Int(-@this.z, -@this.x, -@this.y);

        public static Vector3Int CubicRotateCounterClockwise(this Vector3Int @this) => 
            new Vector3Int(-@this.y, -@this.z, -@this.x);
    }
}
