using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum EWorldState
{
    Disabled,
    Enabled
}

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(MeshRenderer))]
public class Item : MonoBehaviour, IInteractable
{
    public BaseItemData ItemData;
    public float RespawnTime = 0f;
    public bool IsInteractable = true;

    public EWorldState WorldState { get; private set; }

    private SphereCollider _collider;
    private MeshRenderer _renderer;
   

    [SerializeField] private bool _persistAfterPickup;

    private void Awake()
    {
        if(ItemData == null)
        {
            Debug.LogError($"Item {name} in world has no ItemData attached to it.");
            return;
        }

        name = "(Item): " + ItemData.ItemName;
        _collider = GetComponent<SphereCollider>();
        _collider.isTrigger = true;

        _renderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        WorldState = EWorldState.Enabled;
    }

    public bool CanInteract()
    {
        return IsInteractable;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public string GetInteractableAction()
    {
        return "Pickup";
    }

    public string GetName()
    {
        return ItemData.ItemName;
    }

    public void Interact()
    {
        if(PlayerInventory.AddItem(ItemData))
        {
            if (_persistAfterPickup)
            {
                return;
            }

            SetWorldState(EWorldState.Disabled);
            PlayerInteractor.OnInteractableOverlap(this, true);
            if (RespawnTime > 0)
            {
                StartCoroutine(Respawn());
            }
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(RespawnTime);
        SetWorldState(EWorldState.Enabled);
    }

    private void SetWorldState(EWorldState state)
    {
        WorldState = state;
        switch (WorldState)
        {
            case EWorldState.Disabled:
            {
                IsInteractable = false;
                _collider.enabled = false;
                _renderer.enabled = false;
                break;
            }
            case EWorldState.Enabled:
            {
                IsInteractable = true;
                _collider.enabled = true;
                _renderer.enabled = true;
                break;
            }
        }
    }
}
