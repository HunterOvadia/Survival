using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IInteractable
{
    void Interact();
    string GetName();
    string GetInteractableAction();

    GameObject GetGameObject();
}
