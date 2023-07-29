using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class NoteCount : MonoBehaviour
{
    public List <UnityEngine.UI.Image> notes;
    public Sprite noteOn;
    public Sprite noteOff;


    private int totalNotesCount;


    // Start is called before the first frame update
    void Start()
    {
        totalNotesCount = notes.Count;
        NoteSystem.OnNoteChange += ChangeNoteCount;
        UpdateNoteUI();
    }

    public void UpdateNoteUI()
    {
        for (int i = 0; i < NoteSystem.Notes; i++)
        {
            notes[i].sprite = noteOn;
        }
        for (int i = NoteSystem.Notes; i < totalNotesCount; i++)
        {
            notes[i].sprite = noteOff;
        }
    }

    public void ChangeNoteCount(int count)
    {
        UpdateNoteUI();
    }
}
