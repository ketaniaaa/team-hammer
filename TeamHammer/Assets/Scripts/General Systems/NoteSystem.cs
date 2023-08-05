using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSystem : MonoBehaviour
{
    private static int m_notes=3;
    public static int Notes
    {
        get
        {
            return m_notes;
        }
        set
        {
            if (value <= 3)
            {
                m_notes = value;
                OnNoteChange.Invoke(m_notes);
            }
            else
                Debug.Log("Reached note limit");
            ;
        }
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void Init()
    {
        Debug.Log("notes reset.");
        m_notes = 3;
    }


    public static event Action <int>OnNoteChange;



}
