using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Interaction
{
    public interface IInteractable
    {
        bool isInteractable { get; }
        void Interact();
    }
}
