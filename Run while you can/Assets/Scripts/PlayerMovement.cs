using System;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private LinePosition currentLinePosition;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
    }

    public void MoveLeft()
    {
        switch (currentLinePosition)
        {
            case LinePosition.Left:
                break;
            case LinePosition.Middle:
                currentLinePosition = LinePosition.Left;
                break;
            case LinePosition.Right:                
                currentLinePosition = LinePosition.Middle;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        Move();
    }

    public void MoveRight()
    {
        switch (currentLinePosition)
        {
            case LinePosition.Left:
                currentLinePosition = LinePosition.Middle;
                break;
            case LinePosition.Middle:
                currentLinePosition = LinePosition.Right;
                break;
            case LinePosition.Right:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
       Move();
    }
    
    private void Move()
    {
        transform.DOMoveX(Mathf.Clamp((int) currentLinePosition, -2, 2), 0.2f);
    }
}