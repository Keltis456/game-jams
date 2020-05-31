using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectAdaptation : MonoBehaviour
{
    void Start()
    {
        Debug.Log(Camera.main.aspect);
        Camera.main.orthographicSize = 5 * 0.5625f / Camera.main.aspect;
    }
}
