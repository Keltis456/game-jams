using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBox : MonoBehaviour
{
    public new Rigidbody2D rigidbody2D;
    private Rigidbody2D caller;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Freeze(true);
    }

    public void Freeze(bool freeze)
    {
        rigidbody2D.isKinematic = freeze;
    }
}