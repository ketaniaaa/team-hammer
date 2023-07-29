using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MousePosition : MonoBehaviour
{
    [SerializeField] private Camera camera;

    public Vector2 GetMousePosition(InputAction.CallbackContext context)
    {
        if (context.started)
         return camera.ScreenToWorldPoint(Input.mousePosition);
        else 
          return new Vector2(0, 0);
    }
}
