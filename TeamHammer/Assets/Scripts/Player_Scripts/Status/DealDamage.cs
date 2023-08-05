using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] float damage= 20;
    [SerializeField] LayerMask layerMask;
    static float damageBoost =0; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((layerMask & (1 << collision.gameObject.layer)) > 0)
        {
            collision.gameObject.GetComponentInChildren<Health>()?.GotHit(damage+damageBoost); //this is so bad but whatever
            Debug.Log("this hits target");
        }
        Debug.Log("trigger got called at least");
    }

    public static void BoostDamage()
    {
        damageBoost += 5; 
    }

}
