using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    [SerializeField] private MousePosition mousePosition;
    Animator animator;


    //enum Direction = { "Up", "Down", "Left", "Right", "UpRight", "DownRight", "DownLeft", "UpLeft" };

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void FaceTheCursor()
    {
        Vector2 mouseLocation = mousePosition.GetMousePosition();
        Vector2 playerLocation = transform.position;
        Debug.Log(GetDirection(playerLocation, mouseLocation));
        animator.SetBool(GetDirection(playerLocation, mouseLocation), true);
    }
    private string GetDirection(Vector2 point1, Vector2 point2)
    {
        float angle = CalculateRotation(point1, point2);
        //each of the 8 angle will be 45 degree
        if (angle >= 67.5 && angle < 112.5)
        {
            return "Up";
        }
        else if (angle >= 112.5 && angle < 157.5)
        {
            return "UpLeft";
        }
        else if (angle >= 157.5 && angle < 202.5)
        {
            return "Left";
        }
        else if (angle >= 202.5 && angle < 247.5)
        {
            return "DownLeft";
        }
        else if (angle >= 247.5 && angle < 292.5)
        {
            return "Down";
        }
        else if (angle >= 292.5 && angle < 337.5)
        {
            return "DownRight";
        }
        else if (angle >= 337.5 || angle < 2.5) //special case
        {
            return "Right";
        }
        else if (angle >= 2.5 && angle < 67.5)
        {
            return "UpRight";
        }
        else
            return null; 
    }

    float CalculateRotation(Vector2 point1, Vector2 point2)
    {
        float angle =  Mathf.Atan2(point2.y - point1.y , point2.x-point1.x) * 180 / Mathf.PI;
        if (angle < 0)
        {
            angle += 360; 
        }
        return angle; 
    }
}
