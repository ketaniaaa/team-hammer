using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 4f;
    public float damage = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * transform.right; 
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            collision.gameObject.GetComponent<Health>().GotHit(damage);
            Destroy(gameObject);
        }
    }
}
