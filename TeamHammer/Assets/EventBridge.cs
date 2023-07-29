using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBridge : MonoBehaviour
{
    public void LoseCoins()
    {
        CoinSystem.LoseCoins();
    }
}
