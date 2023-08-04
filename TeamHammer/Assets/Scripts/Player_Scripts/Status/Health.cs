using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] float curHealth; 


    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    //Events
    public UnityEvent OnHit;

    public UnityEvent OnHeal; 

    public UnityEvent OnDeath;


    //Methods
    public void GotHit(float damage)
    {
        curHealth -= damage;
        OnHit.Invoke();

        if (curHealth <= 0 )
        {
             OnDeath.Invoke();
        }
    }

    public void HealToFull()
    {
        curHealth = maxHealth;
        OnHeal.Invoke();
    }

}
