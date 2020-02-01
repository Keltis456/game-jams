using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchedObject : MonoBehaviour
{
    public World GetWorld()
    {
        switch (GetComponentInChildren<SpriteRenderer>().maskInteraction)
        {
            case SpriteMaskInteraction.None:
                return World.None;
            case SpriteMaskInteraction.VisibleInsideMask:
                return World.Primary;
            case SpriteMaskInteraction.VisibleOutsideMask:
                return World.Switched;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void OnEnable()
    {
        WorldSwitcher.WorldSwitched += OnWorldSwitched;
    }
    
    private void OnDisable()
    {
        WorldSwitcher.WorldSwitched -= OnWorldSwitched;
    }

    private void Start()
    {
        OnWorldSwitched(WorldSwitcher.GetCurrentWorld());
    }


    private void OnWorldSwitched(World world)
    {
        foreach (var collider2D in GetComponentsInChildren<Collider2D>())
        {
            switch (GetWorld())
            {
                case World.None:
                    break;
                case World.Primary:
                    collider2D.isTrigger = world == World.Primary;
                    break;
                case World.Switched:
                    collider2D.isTrigger = world == World.Switched;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}