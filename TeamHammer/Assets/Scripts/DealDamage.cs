using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] float damage= 20;
    [SerializeField] LayerMask layerMask; 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == layerMask)
        {
            collision.gameObject.GetComponent<Health>()?. GotHit(damage);
        }
    }
 
}
