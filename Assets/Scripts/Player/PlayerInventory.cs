using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private static ItemList _inventory;

    public delegate void OnItemAddedDelegate(BaseItemData item);
    public static OnItemAddedDelegate OnItemAdded;

    public void Awake()
    {
        _inventory = Resources.Load("ItemLists/PlayerInventory", typeof(ItemList)) as ItemList;
    }

    public static bool AddItem(BaseItemData item)
    {
        if(_inventory.AddItem(item))
        {
            OnItemAdded?.Invoke(item);
            return true;
        }

        return false;
    }

    public static void RemoveItem(BaseItemData item)
    {
        _inventory.RemoveItem(item);
    }
}
