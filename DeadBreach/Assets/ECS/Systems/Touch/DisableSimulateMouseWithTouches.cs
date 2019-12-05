using Entitas;
using UnityEngine;

namespace DeadBreach.ECS.Systems.Touch
{
    internal class DisableSimulateMouseWithTouches : IInitializeSystem
    {
        public void Initialize() =>
            Input.simulateMouseWithTouches = false;
    }
}
