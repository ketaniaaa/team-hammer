using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float dashSpeed = 20;
    [SerializeField] float dashDuration = 0.2f;
    [SerializeField] bool isDashing = false;
    [SerializeField] float dashCooldown= 2f; 
    [SerializeField] bool canDash = true; 


    private PlayerDirection playerDirection;


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
        if (isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
        MatchDirectionToMovement();
    }
    
    public void OnDash()
    {
        StartCoroutine(Dash());
    }
    
    IEnumerator Dash()
    {
        if (canDash)
        {
            isDashing = true;
            rb.velocity = new Vector2(moveInput.x * dashSpeed, moveInput.y * dashSpeed);
            canDash = false;
            yield return new WaitForSeconds(dashDuration);
            isDashing = false;
            yield return new WaitForSeconds(dashCooldown);
            canDash = true;
        }
    }
    


    //animation direction
    Animator animator;

    private void MatchDirectionToMovement()
    {
        Direction direction= Direction.Up;
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



}
