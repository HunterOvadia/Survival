using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private static ItemList _inventory;

    public void Awake()
    {
        _inventory = Resources.Load("ItemLists/PlayerInventory", typeof(ItemList)) as ItemList;
    }

    public static void AddItem(BaseItemData item)
    {
        _inventory.AddItem(item);
    }

    public static void RemoveItem(BaseItemData item)
    {
        _inventory.RemoveItem(item);
    }
}
