using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class CoinSystem : MonoBehaviour
{
    private static int m_coins=10;
    public static int Coins
    {
        get
        {
        return m_coins;
        }
        set
        {
        m_coins = value;
        OnCoinChange.Invoke(m_coins); 
        }
    }

    public static event Action <int>OnCoinChange;

    public static void LoseCoins()
    {
        Coins = 0;
    }



}
