using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/Item List")]
public class ItemList : ScriptableObject
{
    [SerializeField]
    private List<BaseItemData> Items = new List<BaseItemData>();

    // TODO(Hunter): Item Count
    public void AddItem(BaseItemData item)
    {
        Items.Add(item);
    }

    // TODO(Hunter): Item Count
    public void RemoveItem(BaseItemData item)
    {
        Items.Remove(item);
    }
}
