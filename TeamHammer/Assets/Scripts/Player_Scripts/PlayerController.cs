using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float dashSpeed = 10;
    PlayerDirection playerDirection;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerDirection = GetComponent<PlayerDirection>();
    }



    //movement
    private Rigidbody2D rb;
    private Vector2 moveInput;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
        MatchDirectionToMovement();
    }

    private void MatchDirectionToMovement()
    {
        Direction direction= Direction.None;
        if (moveInput.x > 0) //move to the right
        {
            if (moveInput.y > 0)
                direction = Direction.UpRight;
            else if (moveInput.y < 0)
                direction = Direction.DownRight;
            else
                direction = Direction.Right;
        }
        else if (moveInput.x < 0)
        {
            if (moveInput.y > 0)
                direction = Direction.UpLeft;
            else if (moveInput.y < 0)
                direction = Direction.DownLeft;
            else
                direction = Direction.Left;
        }
        else if (moveInput.x == 0)
        {
            if (moveInput.y > 0)
                direction = Direction.Up;
            if (moveInput.y < 0)
                direction = Direction.Down;
        }
        playerDirection.ChangeDirection(direction);
    }

    /*
    public void OnDash()
    {
        StartCoroutine(Dash());

    }

    
    IEnumerator Dash()
    {
        
    }
    */

    //need to set up character direction first

    //animation
    Animator animator;



    
        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
