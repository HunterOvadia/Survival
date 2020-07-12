using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(SphereCollider))]
public class NPC : MonoBehaviour, IInteractable
{
    public BaseNPCData Data;
    [SerializeField] private TextMeshPro _nameText;
    private SphereCollider _collder;

    private void Awake()
    {
        name = "(NPC): " + Data.NPCName;
        _nameText.text = Data.NPCName;
        _nameText.color = Data.Flags.IsSet(NPCFlags.FLAG_FRIENDLY) ? Color.green : Color.red;

        _collder = GetComponent<SphereCollider>();
        _collder.isTrigger = true;
    }

    public GameObject GetGameObject() 
    {
        return gameObject;
    }

    public string GetInteractableAction()
    {
        return "Talk to";
    }

    public string GetName()
    {
        return Data.NPCName;
    }

    public bool CanInteract()
    {
        return Data.Flags.IsSet(NPCFlags.FLAG_FRIENDLY) &&
               Data.Flags.IsSet(NPCFlags.FLAG_DIALOGUE) ||
               Data.Flags.IsSet(NPCFlags.FLAG_QUESTGIVER) ||
               Data.Flags.IsSet(NPCFlags.FLAG_SHOP);
    }

    public void Interact()
    {
        if(Data.Flags.IsSet(NPCFlags.FLAG_DIALOGUE))
        {
            DialogueManager.OnBeginDialogue?.Invoke(Data.Dialogue, GetName());
        }
    }
}