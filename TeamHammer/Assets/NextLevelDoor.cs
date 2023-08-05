using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class NextLevelDoor : MonoBehaviour
{
    Collider2D door;

    private void Awake()
    {
        door = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GoToNextLevel();
        }
    }

    private void Start()
    {
      //  NextLevel.AddListener(LoadNextLevel);   work in progress- only load next level after you have close the shop!!! so add it to oncloseshop
    }
    public void GoToNextLevel()
    {
        NextLevel.Invoke();
    }

    public void LoadNextLevel()
    {
        // Get the current active scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene based on the current scene index + 1
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public UnityEvent NextLevel;

}
