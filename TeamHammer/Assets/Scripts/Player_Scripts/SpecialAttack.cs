using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpecialAttack : MonoBehaviour
{

    [SerializeField] GameObject attackProjectilePrefab;
    [SerializeField] GameObject indicator; 
    [SerializeField] float range; 

    public  MousePosition mouse;

    private void Awake()
    {
        mouse = GetComponent<MousePosition>();
        if (mouse != null)
            Debug.Log("mouse null");
    }

    public void PerformSpecialAttack(InputAction.CallbackContext context)
    {
        if (NoteSystem.Notes > 0)
        {
            Vector2 mouseLocation = mouse.GetMouseLocation();
            if (context.started)
            {
                indicator.SetActive(true);
                Time.timeScale = 0.5f;
            }

            if (context.canceled)
            {
                indicator.SetActive(false);
                GameObject attackTemp= Instantiate(attackProjectilePrefab); 
                attackTemp.transform.position = mouseLocation;
                NoteSystem.Notes--;
                Time.timeScale = 1f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        indicator.transform.position = mouse.GetMouseLocation();
    }
}
