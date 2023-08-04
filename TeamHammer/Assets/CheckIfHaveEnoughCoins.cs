using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CheckIfHaveEnoughCoins : MonoBehaviour
{
    private Button button;

    [SerializeField] int cost;
    [SerializeField] TextMeshProUGUI text;


    private void Awake()
    {
        button = GetComponent<Button>();
    }
    public void CheckForCoinsOnClick()
    {
        if (CoinSystem.Coins >= cost)
        {
            OnBuy.Invoke();
            CoinSystem.Coins -= cost;
        }
        else
            text.text = "You don't have enough coins";

    }

    public UnityEvent OnBuy; 
}
