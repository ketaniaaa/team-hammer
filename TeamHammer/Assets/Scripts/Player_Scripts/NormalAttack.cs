using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NormalAttack : MonoBehaviour
{
    public void PerformNormalAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (NoteSystem.Notes > 0)
            {
                //do speical attack here
            }
        }

    }
}
