using Cars.Features;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestsSystem
{
    public abstract class QuestTrigger : MonoBehaviour, IInteractable
    {
        public string TaskKeyname;
        public bool DestroyTriggerAfterTriggered;
        public bool DestroyObjAfterTriggered;
        public bool InteractByFinger;
        public void Interact()
        {
            if (InteractByFinger == false)
                return;

            OnQuestTriggered();
            if (DestroyObjAfterTriggered)
            {
                Destroy(gameObject);
                return;
            }
            if (DestroyTriggerAfterTriggered)
            {
                Destroy(this);
            }
        }
        public abstract void OnQuestTriggered();
    }
}
