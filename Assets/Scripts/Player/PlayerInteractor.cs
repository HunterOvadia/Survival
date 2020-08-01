using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public delegate void OnInteractableOverlapDelegate(IInteractable interactable, bool exit);
    public static OnInteractableOverlapDelegate OnInteractableOverlap;

    private IInteractable _currentInteractable;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IInteractable interactable))
        {
            if (interactable.CanInteract())
            {
                OnInteractableOverlap?.Invoke(interactable, false);
                _currentInteractable = interactable;
            }
        }
    }

    private void Update()
    {
        if(_currentInteractable != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(_currentInteractable.CanInteract())
                {
                    _currentInteractable.Interact();
                }
            }
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            if(_currentInteractable != null && interactable.GetHashCode() == _currentInteractable.GetHashCode())
            {
                if (interactable.CanInteract())
                {
                    OnInteractableOverlap?.Invoke(interactable, true);
                    _currentInteractable = null;
                }
            }
        }
    }
}
