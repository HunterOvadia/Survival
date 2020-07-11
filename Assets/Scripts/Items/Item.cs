using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Item : MonoBehaviour, IInteractable
{
    public BaseItemData ItemData;

    private SphereCollider _collider;

    [SerializeField] private bool _persistAfterPickup;

    public void Awake()
    {
        if(ItemData == null)
        {
            Debug.LogError($"Item {name} in world has no ItemData attached to it.");
            return;
        }
        name = "(Item): " + ItemData.ItemName;

        _collider = GetComponent<SphereCollider>();
        if(_collider != null)
        {
            _collider.isTrigger = true;
        }
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

            Destroy(gameObject);
            PlayerInteractor.OnInteractableOverlap(this, true);
        }
    }
}
