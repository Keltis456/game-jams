using UnityEngine;

namespace DeadBreach.ECS
{
    public struct TweenTransform
    {
        public Vector3 Position { get; }
        public Vector3 Rotation { get; }
        public Vector3 Scale { get; }

        public TweenTransform(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }
    }
}