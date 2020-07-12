using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class OnInteractEvent : UnityEvent { }

public enum eInteractableState
{
    ON,
    OFF
}

public class WorldInteractable : MonoBehaviour, IInteractable
{
    public string Name;
    public string Action;
    public eInteractableState State = eInteractableState.ON;
    public bool IsInteractable = true;

    public OnInteractEvent OnInteractOn;
    public OnInteractEvent OnInteractOff;

    public bool CanInteract()
    {
        return IsInteractable;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public string GetInteractableAction()
    {
        return Action;
    }

    public string GetName()
    {
        return Name;
    }

    public void Interact()
    {
        if(State == eInteractableState.ON)
        {
            OnInteractOff?.Invoke();
            State = eInteractableState.OFF;
        }
        else if(State == eInteractableState.OFF)
        {
            OnInteractOn?.Invoke();
            State = eInteractableState.ON;
        }
    }



    /* === HELPERS === */
    public void SetAction(string newAction)
    {
        Action = newAction;
        PlayerInteractor.OnInteractableOverlap?.Invoke(this, false);
    }
}

