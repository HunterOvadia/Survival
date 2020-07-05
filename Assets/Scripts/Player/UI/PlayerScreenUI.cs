using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScreenUI : MonoBehaviour
{
    [Header("Player Components")]
    public PlayerVitals Vitals;

    [Header("UI Components")]
    public Slider HealthBar;
    public TextMeshProUGUI InteractionText;

    private void Start()
    {
        Vitals.GetVital(eVitalType.HEALTH).OnUpdate += OnHealthUpdate;
        PlayerInteractor.OnInteractableOverlap += OnInteractableOverlap;

        InteractionText.gameObject.SetActive(false);
    }

    private void OnInteractableOverlap(IInteractable interactable, bool exit)
    {
        if(!exit)
        {
            InteractionText.text = interactable.GetInteractableAction() + " '" + interactable.GetName() + "'";
            InteractionText.gameObject.SetActive(true);
        }
        else
        {
            InteractionText.text = string.Empty;
            InteractionText.gameObject.SetActive(false);
        }
    }

    private void OnHealthUpdate(float newAmount, float maxAmount)
    {
        HealthBar.maxValue = maxAmount;
        HealthBar.value = newAmount;
    }
}
