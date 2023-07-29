using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount :MonoBehaviour
{
    [SerializeField] Text text; 
    private int coins=0;

    // Start is called before the first frame update
    void Start()
    {
        text.text = coins + " x";
        CoinSystem.OnCoinChange += ChangeCoinCount;
    }

    public void ChangeCoinCount(int count)
    {
        coins= count;
        text.text = coins + " x";
    }

   
}
