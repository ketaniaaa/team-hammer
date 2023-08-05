using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
   public GameObject shop; 
   public void OnOpenShop()
    {
        shop.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
    }

    public void OnCloseShop()
    {
        shop.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }
}
