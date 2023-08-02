using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MousePosition : MonoBehaviour
{
    [SerializeField]private GameObject mouseIcon;  

    private Vector2 mouseLocation;

    private void Start()
    {
      Cursor.visible = false;
    }

    private void Update()
    {
        mouseLocation = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        mouseIcon.transform.position = mouseLocation;
    }

    public Vector2 GetMouseLocation()
    {
        return mouseLocation;  
    }


}
