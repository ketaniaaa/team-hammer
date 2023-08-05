using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBehaviour : MonoBehaviour
{

    public AIPath aiPath; 
    Animator animator;
    public Collider2D playerDetection;
    public float ChanceToDropNote = 0.5f;
    public GameObject Note;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        aiPath.target = GameObject.Find("Player").transform;
        aiPath.enabled = false; 
    }


    public void OnDeath()
    {
        if (Random.Range(0f,1f) > ChanceToDropNote)
        {
            Instantiate(Note, transform);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        aiPath.enabled = true;
        Debug.Log("Detected Player");
    }
    private void Update()
    {
        if (aiPath.desiredVelocity.y > 0.01)
        {
            animator.Play("Up");
            //animator.SetBool("Up", true);
        }
        else if (aiPath.desiredVelocity.y < 0.01)
        {
            animator.Play("down");
            // animator.SetBool("Down", true);
        }
        if (aiPath.desiredVelocity.x > 0.01) //right
        {
            //animator.SetBool("Right", true);
            animator.Play("Right");
        }
        else if (aiPath.desiredVelocity.x < 0.01)
        {
            animator.Play("Left");
            //animator.SetBool("Left", true);
        }

        }
    }


