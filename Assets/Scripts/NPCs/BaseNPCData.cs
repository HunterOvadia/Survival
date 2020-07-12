using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "NPC", menuName = "NPCs/NPC")]
public class BaseNPCData : ScriptableObject
{
    public string NPCName = "Default";
    public NPCFlags Flags;
    public Dialogue Dialogue;
}
