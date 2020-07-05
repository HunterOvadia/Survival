using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerInventorySlotUI : MonoBehaviour
{
    public ItemListItem ReferenceItem;
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TextMeshProUGUI _itemCount;


    public void UpdateSlot(ItemListItem referenceItem)
    {
        if(referenceItem != null)
        {
            ReferenceItem = referenceItem;
            _itemIcon.sprite = ReferenceItem.Data.Icon;
            _itemCount.text = "" + referenceItem.Count;
        }
        else
        {
            ReferenceItem = null;
            _itemCount.text = "";
            _itemIcon.sprite = null;
        }
    }
}
