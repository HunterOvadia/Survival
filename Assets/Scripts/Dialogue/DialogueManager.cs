using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _dialogueText;

    public delegate void BeginDialogueDelegate(Dialogue d, string senderName);
    public static BeginDialogueDelegate OnBeginDialogue;

    public delegate void EndDialogueDelegate();
    public static EndDialogueDelegate OnEndDialogue;

    private bool _isDialogueActive = false;
    private Dialogue _currentDialogue;
    private int _currentDialogueIndex;

    private void Awake()
    {
        OnBeginDialogue += BeginDialogue;
        OnEndDialogue += EndDialogue;
        PlayerInteractor.OnInteractableOverlap += OnInteractableOverlap;

        _panel.SetActive(false);
    }

    private void OnInteractableOverlap(IInteractable interactable, bool exit)
    {
        if (exit && _isDialogueActive)
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        _currentDialogue = null;
        _currentDialogueIndex = 0;

        _panel.SetActive(false);
        _isDialogueActive = false;
    }
    
    private void Update()
    {
        if(_isDialogueActive)
        {
            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                NextDialogue();
            }
        }
    }

    public void BeginDialogue(Dialogue dialogue, string senderName)
    {
        if (dialogue == null)
            return;

        _currentDialogue = dialogue;
        _currentDialogueIndex = 0;

        _name.text = senderName;
        _dialogueText.text = dialogue.DialogueData[_currentDialogueIndex].DialogueText;
        _panel.SetActive(true);
        _isDialogueActive = true;
    }

    private void NextDialogue()
    {
        if (_currentDialogue == null)
            return;

        ++_currentDialogueIndex;
        if(_currentDialogueIndex >= _currentDialogue.DialogueData.Count)
        {
            EndDialogue();
            return;
        }

        _dialogueText.text = _currentDialogue.DialogueData[_currentDialogueIndex].DialogueText;
    }
}
