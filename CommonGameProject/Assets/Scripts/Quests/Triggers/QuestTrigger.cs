using Cars.Features;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestsSystem
{
    public abstract class QuestTrigger : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            OnQuestTrigger();
        }
        public abstract void OnQuestTrigger();
    }
}
