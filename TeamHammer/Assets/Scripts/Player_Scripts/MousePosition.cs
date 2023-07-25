using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField] private Camera camera;

    public Vector2 GetMousePosition()
    {
       return camera.ScreenToWorldPoint(Input.mousePosition);
    }
}
