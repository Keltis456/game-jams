using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float smoothingSpeed;
    [SerializeField] private Vector3 offset;
    private GameObject target;

    private void Update()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player");
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
            transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, smoothingSpeed);
    }
}
