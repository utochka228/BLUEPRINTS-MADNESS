using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestsSystem
{
    /// <summary>Quests manager for each level</summary>
    public class Quester : MonoBehaviour
    {
        public static Quester instance;

        public delegate void QuestUpdates();
        public event QuestUpdates OnQuestUpdated;

        private Quest LevelQuest;
        private Queue<StageQuest> StageQueue;

        public void SetLevelQuest(Quest levelQuest)
        {
            LevelQuest = levelQuest;
            StageQueue = new Queue<StageQuest>();
            foreach (var stage in LevelQuest.TargetQuestObject.QuestStages)
            {
                StageQueue.Enqueue(stage);
            }
        }

        public void PassStage()
        {
            StageQueue.Dequeue();
            if(StageQueue.Count == 0)
            {
                Debug.Log("Level end!");
            }
        }
    }
}
