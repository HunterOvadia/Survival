using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "Items/Item")]
public class BaseItemData : ScriptableObject
{
    public string ItemName = "Default";
    public Sprite Icon;
    public int MaxCount = -1;
    public int MaxPerStack = -1;
}
