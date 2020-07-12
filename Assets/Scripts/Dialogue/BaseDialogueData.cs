using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "DialogueData", menuName = "Dialogue/Dialogue Data")]
public class BaseDialogueData : ScriptableObject
{
    [TextArea(3, 10)]
    public string DialogueText = "Lorem Ipsum";
}
