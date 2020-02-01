using System;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0, 10f)] [SerializeField] private float speed = 5f;
    [Range(0, 500f)] [SerializeField] private float jumpForce = 200f;
    [SerializeField] private Collider2D bodyCollider;
    [SerializeField] private Collider2D legsCollider;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundedRadius;
    [SerializeField] private LayerMask whatIsGround;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
    [SerializeField] private Transform switchMask;
    
    private Vector3 velocity = Vector3.zero;
    private new Rigidbody2D rigidbody2D;
    private bool isGrounded;
    private bool facingRight;
    private bool rightWallTouched;
    private bool leftWallTouched;

    private float inputMove;
    private bool inputJump;
    private bool inputInteract;
    private bool inputSwitch;
    
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        inputMove = Input.GetAxisRaw("Horizontal");
        inputJump = Input.GetAxisRaw("Jump") > 0;
        inputInteract = Input.GetButtonDown("Interact");
        inputSwitch = Input.GetButtonDown("Switch");
        SwitchOnInput();

    }
	
    private void FixedUpdate()
    {
        CheckGrounded();
        CheckWalls();

        MoveOnInput();
        JumpOnInput();
    }

    private void SwitchOnInput()
    {
        if (!inputSwitch)
        {
            return;
        }
        if (WorldSwitcher.GetCurrentWorld() == World.Switched)
        {
            HideSwitchMask();
        }
        else
        {           
            ShowSwitchMask();
        }
        WorldSwitcher.SwitchWorld();
        Debug.Log("Switch");
    }

    private void ShowSwitchMask()
    {
        switchMask.DOScale(0f, 1f);
    }

    private void HideSwitchMask()
    {
        switchMask.DOScale(40f, 1f);
    }

    private void MoveOnInput()
    {
        if (inputMove > 0)
        {
            MoveRight();
        }
        else if (inputMove < 0)
        {
            MoveLeft();
        }
        else if (inputMove == 0)
        {
            Move();
        }
    }

    private void JumpOnInput()
    {
        if (isGrounded && inputJump)
        {
            isGrounded = false;
            rigidbody2D.AddForce(new Vector2(0f, jumpForce));
        }
    }

    private void MoveLeft()
    {
        if (!leftWallTouched) 
            Move();

        if (facingRight)
        {
            Flip();
        }
    }

    private void MoveRight()
    {
        if (!rightWallTouched) 
            Move();

        if (!facingRight)
        {
            Flip();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(RightWallCheckerPosition(), WallCheckerSize());
        Gizmos.DrawCube(LeftWallCheckerPosition(), WallCheckerSize());
    }

    private void Move()
    {
        Vector3 targetVelocity = new Vector2(inputMove * speed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref velocity, movementSmoothing);
    }

    private void CheckGrounded()
    {
        isGrounded = false;
        foreach (var collider2D1 in Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround))
        {
            if (!collider2D1.isTrigger)
            {
                isGrounded = true;
                break;
            }
        }
    }
    private void CheckWalls()
    {
        rightWallTouched = false;
        leftWallTouched = false;
        foreach (var collider2D1 in Physics2D.OverlapBoxAll(RightWallCheckerPosition(), WallCheckerSize(),0f, whatIsGround))
        {
            if (!collider2D1.isTrigger)
            {
                rightWallTouched = true;
                break;
            }
        }
        
        foreach (var collider2D1 in Physics2D.OverlapBoxAll(LeftWallCheckerPosition(), WallCheckerSize(),0f, whatIsGround))
        {
            if (!collider2D1.isTrigger)
            {
                leftWallTouched = true;
                break;
            }
        }
    }

    private Vector2 WallCheckerSize() => new Vector2(0.1f, bodyCollider.bounds.size.y);
    private Vector2 RightWallCheckerPosition() => new Vector2(bodyCollider.bounds.center.x + bodyCollider.bounds.extents.x + 0.01f, bodyCollider.bounds.center.y);
    private Vector2 LeftWallCheckerPosition() => new Vector2(bodyCollider.bounds.center.x - bodyCollider.bounds.extents.x - 0.01f, bodyCollider.bounds.center.y);

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}