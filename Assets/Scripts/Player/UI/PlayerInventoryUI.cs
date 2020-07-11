using System;
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

        PlayerInventory.OnItemAdded += OnItemAdded;
    }


    private void Start()
    {
        ToggleInventoryPanel(false);
        RefreshItems();
    }

    private void OnItemAdded(BaseItemData item)
    {
        RefreshItems();
    }

    private void RefreshItems()
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            if(i < _inventoryItemList.Items.Count)
            {
                ItemListItem item = _inventoryItemList.Items[i];
                _slots[i].UpdateSlot(item);
            }
            else
            {
                _slots[i].UpdateSlot(null);
            }
        }
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
    }
}
