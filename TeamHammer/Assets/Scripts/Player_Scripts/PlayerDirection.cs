using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDirection : MonoBehaviour
{
    Animator animator;
    private Direction currentDirection= Direction.None;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public Direction GetDirection()
    {
        return currentDirection;
    }
    public void ChangeDirection(Direction direction)
    {
        string directionInString = null;
        switch (direction)
        {
            case Direction.Up:
                directionInString = "Up";
                currentDirection = Direction.Up;
                break;
            case Direction.Down:
                directionInString = "Down";
                currentDirection = Direction.Down;
                break;
            case Direction.Left:
                directionInString = "Left";
                currentDirection = Direction.Left;
                break;
            case Direction.Right:
                directionInString = "Right";
                currentDirection = Direction.Right;
                break;
            case Direction.UpRight:
                directionInString = "UpRight";
                    currentDirection = Direction.UpRight;
                break;
            case Direction.DownRight:
                directionInString = "DownRight";
                currentDirection = Direction.DownRight;
                break;
            case Direction.DownLeft:
                directionInString = "DownLeft";
                currentDirection = Direction.DownLeft;
                break;
            case Direction.UpLeft:
                directionInString = "UpLeft";
                currentDirection = Direction.UpLeft;
                break;
        }
        if (!animator.GetBool(directionInString))
        {
            SetInAnimator(directionInString);
        }
    }

    //METHODS
  
    [SerializeField] private MousePosition mousePosition;
    public void FaceTheCursor(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Vector2 mouseLocation = mousePosition.GetMousePosition(context);
            Vector2 playerLocation = transform.position;
            Direction direction= (GetDirectionBetweenTwoPoints(playerLocation, mouseLocation));
            ChangeDirection(direction);
        }
    }


    private Direction GetDirectionBetweenTwoPoints(Vector2 point1, Vector2 point2)
    {
        float angle = CalculateRotation(point1, point2);
        //each of the 8 angle will be 45 degree
        if (angle >= 67.5 && angle < 112.5)
        {
            return Direction.Up;
        }
        else if (angle >= 112.5 && angle < 157.5)
        {
            return Direction.UpLeft;
        }
        else if (angle >= 157.5 && angle < 202.5)
        {
            return Direction.Left;
        }
        else if (angle >= 202.5 && angle < 247.5)
        {
            return Direction.DownLeft;
        }
        else if (angle >= 247.5 && angle < 292.5)
        {
            return Direction.Down;
        }
        else if (angle >= 292.5 && angle < 337.5)
        {
            return Direction.DownRight;
        }
        else if (angle >= 337.5 || angle < 2.5) //special case
        {
            return Direction.Right;
        }
        else if (angle >= 2.5 && angle < 67.5)
        {
            return Direction.UpRight;
        }
        else
            return Direction.None;
    }

    static float CalculateRotation(Vector2 point1, Vector2 point2)
    {
        float angle =  Mathf.Atan2(point2.y - point1.y , point2.x-point1.x) * 180 / Mathf.PI;
        if (angle < 0)
        {
            angle += 360; 
        }
        return angle; 
    }


    void SetInAnimator(string facingDirection)
    {
        animator.SetBool("Up", false);
        animator.SetBool("Down", false);
        animator.SetBool("Right", false);
        animator.SetBool("Left", false);
        animator.SetBool("UpLeft", false);
        animator.SetBool("UpRight", false);
        animator.SetBool("DownLeft", false);
        animator.SetBool("DownRight", false);

        animator.SetBool(facingDirection, true);
    }
}
