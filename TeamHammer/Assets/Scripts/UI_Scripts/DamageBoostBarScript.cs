using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageBoostBarScript : MonoBehaviour
{
    [SerializeField] Slider slider; 

   public void IncrementSliderValue()
    {
        slider.value++;
    }
}
