using System;

public static class WorldSwitcher
{
    public static event Action<World> WorldSwitched;

    private static World currentWorld = World.Primary;

    public static World GetCurrentWorld()
    {
        return currentWorld;
    }
    
    public static void SwitchWorld()
    {
        switch (currentWorld)
        {
            case World.None:
                break;
            case World.Primary:
                currentWorld = World.Switched;
                break;
            case World.Switched:
                currentWorld = World.Primary;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        WorldSwitched?.Invoke(currentWorld);
    }
}