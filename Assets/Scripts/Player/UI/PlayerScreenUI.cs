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
    public TextMeshProUGUI SystemAlertText;

    private void Start()
    {
        Vitals.GetVital(eVitalType.HEALTH).OnUpdate += OnHealthUpdate;
        PlayerInteractor.OnInteractableOverlap += OnInteractableOverlap;
        GameManager.OnSystemMessageReceived += OnSystemMessageReceived;

        SystemAlertText.gameObject.SetActive(false);
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

    private void OnSystemMessageReceived(string message)
    {
        SystemAlertText.text = message;
        SystemAlertText.gameObject.SetActive(true);

        StopCoroutine(ClearSystemAlert());
        StartCoroutine(ClearSystemAlert());
    }

    private IEnumerator ClearSystemAlert()
    {
        yield return new WaitForSeconds(3.0f);
        SystemAlertText.gameObject.SetActive(false);
    }
}
