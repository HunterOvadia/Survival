using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("Player Components")]
    public PlayerVitals Vitals;

    [Header("UI Components")]
    public Slider HealthBar;

    private void Start()
    {
        Vitals.GetVital(eVitalType.HEALTH).OnUpdate += OnHealthUpdate;    
    }

    private void OnHealthUpdate(float newAmount, float maxAmount)
    {
        HealthBar.maxValue = maxAmount;
        HealthBar.value = newAmount;
    }
}
