using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class CointSystem : MonoBehaviour
{
    private int m_coins=0;
    public int Coins
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

    public UnityEvent <int>OnCoinChange;

    public void LoseCoins()
    {
        Coins = 0;
    }

}
