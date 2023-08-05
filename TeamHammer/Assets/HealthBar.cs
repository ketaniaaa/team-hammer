using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider; 
    [SerializeField] Health health;

    private void Start()
    {
        UpdateHealthBarUI();
    }
    public void UpdateHealthBarUI()
    {
        slider.value = health.GetCurHealth() / health.GetMaxHealth();
    }
}
