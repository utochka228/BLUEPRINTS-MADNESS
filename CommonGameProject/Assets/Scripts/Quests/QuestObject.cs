using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestsSystem
{
    [CreateAssetMenu]
    public class QuestObject : ScriptableObject
    {
        public List<StageQuest> QuestStages;
    }
}
