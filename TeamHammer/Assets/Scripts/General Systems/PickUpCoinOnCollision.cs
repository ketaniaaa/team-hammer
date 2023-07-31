using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoinOnCollision : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            {
            CoinSystem.Coins++;
            Destroy(gameObject);
            }
    }

}
