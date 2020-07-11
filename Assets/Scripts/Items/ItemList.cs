using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class ItemListItem
{
    public BaseItemData Data;
    public int Count;

    public ItemListItem(BaseItemData data)
    {
        Data = data;
        Count = 1;
    }
}

[CreateAssetMenu(fileName = "Item", menuName = "Items/Item List")]
public class ItemList : ScriptableObject
{
    public List<ItemListItem> Items = new List<ItemListItem>();

    public bool AddItem(BaseItemData newItem)
    {
        ItemListItem lastExistingItem = Items.FindLast(item => item.Data.ItemName == newItem.ItemName);

        // If this item does not exist, just add to our inventory
        if(lastExistingItem == null)
        {
            Items.Add(new ItemListItem(newItem));
            return true;
        }
        else
        {
            int countSum = Items.FindAll(item => item.Data.ItemName == newItem.ItemName).Select(x => x.Count).Sum();
            if (countSum == newItem.MaxCount)
            {
                GameManager.SendSystemMessage($"You cannot pickup any more of this item.");
                return false;
            }

            if(lastExistingItem.Count < newItem.MaxCount || newItem.MaxCount == -1)
            {
                if(lastExistingItem.Count == newItem.MaxPerStack)
                {
                    Items.Add(new ItemListItem(newItem));
                }
                else
                {
                    lastExistingItem.Count++;
                }
            }

            return true;
        }
    }

    // TODO(Hunter): Item Count
    public void RemoveItem(BaseItemData newItem)
    {
        throw new NotImplementedException();
    }
}
