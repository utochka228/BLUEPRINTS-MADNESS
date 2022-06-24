using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestsSystem
{
    public class OnEnterExitQuestTrigger : QuestTrigger
    {
        public bool onEnter;
        public bool onExit;
        private void OnTriggerEnter(Collider other)
        {
            if (onEnter == false)
                return;

            OnQuestTriggered();
        }
        private void OnTriggerExit(Collider other)
        {
            if (onExit == false)
                return;

            OnQuestTriggered();
        }
        public override void OnQuestTriggered()
        {
            
        }
        
    }
}
