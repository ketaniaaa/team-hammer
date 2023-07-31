using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpecialAttack : MonoBehaviour
{
    public void PerformSpecialAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
        if (NoteSystem.Notes > 0)
        {
             //do speical attack here
             NoteSystem.Notes--;
        }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
