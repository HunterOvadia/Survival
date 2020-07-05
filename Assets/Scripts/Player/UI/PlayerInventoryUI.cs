using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventoryUI : MonoBehaviour
{
    public GameObject Panel;
    public GameObject SlotHolder;


    private ItemList _inventoryItemList;
    private List<PlayerInventorySlotUI> _slots = new List<PlayerInventorySlotUI>();

    public bool IsOpen { get; private set; }

    private void Awake()
    {
        _inventoryItemList = (ItemList)Resources.Load("ItemLists/PlayerInventory");
        _slots = SlotHolder.GetComponentsInChildren<PlayerInventorySlotUI>().ToList();
    }

    private void Start()
    {
        ToggleInventoryPanel(false);
        RefreshItems();
    }

    private void RefreshItems()
    {
        int slotIndex = 0;
        for(int i = 0; i < _inventoryItemList.Items.Count; ++i)
        {
            ItemListItem currentItem = _inventoryItemList.Items[i];
            _slots[slotIndex].UpdateSlot(currentItem);
        }
        //int index = 0;
        //for (int i = 0; i < _slots.Count; i++)
        //{
        //    if(i < _inventoryItemList.Items.Count)
        //    {
        //        for(int stacks = 0; stacks < _inventoryItemList.Items[i].Stacks; ++stacks)
        //        {
        //            _slots[i + stacks].UpdateItem(_inventoryItemList.Items[i]);
        //        }
        //    }
        //    else
        //    {
        //        _slots[i].UpdateItem(null);
        //    }
        //}
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventoryPanel(!IsOpen);
        }
    }

    private void ToggleInventoryPanel(bool toggle)
    {
        IsOpen = toggle;
        Panel.SetActive(IsOpen);
        if(toggle)
        {
            RefreshItems();
        }
    }
}
