using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemListItem
{
    public BaseItemData Data;
    public int Stacks;
    public int Count;

    public ItemListItem(BaseItemData data)
    {
        Data = data;
        Stacks = 1;
        Count = 1;
    }
}

[CreateAssetMenu(fileName = "Item", menuName = "Items/Item List")]
public class ItemList : ScriptableObject
{
    public List<ItemListItem> Items = new List<ItemListItem>();

    public void AddItem(BaseItemData newItem)
    {
        ItemListItem existingItem = Items.Find(item => item.Data.ItemName == newItem.ItemName);
        if(existingItem == null)
        {
            Items.Add(new ItemListItem(newItem));
        }
        else
        {
            if(existingItem.Count == newItem.MaxCount) return;
            if(existingItem.Count < newItem.MaxCount || newItem.MaxCount == -1)
            {
                ++existingItem.Count;
                if(existingItem.Count % newItem.MaxPerStack == 1)
                {
                    ++existingItem.Stacks;
                }
            }
        }
    }

    // TODO(Hunter): Item Count
    public void RemoveItem(BaseItemData newItem)
    {
        throw new NotImplementedException();
    }
}
