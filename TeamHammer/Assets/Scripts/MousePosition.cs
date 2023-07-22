using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField] private Camera camera  ;

    private void Update()
    {
        Debug.Log(camera.ScreenToWorldPoint(Input.mousePosition));
    }
}
