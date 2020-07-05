using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public BaseItemData ItemData;
    public void Awake()
    {
        name = ItemData.ItemName;
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
        Destroy(gameObject);
        PlayerInteractor.OnInteractableOverlap(this, true);
        // TODO(Hunter): add to inventory
    }
}
