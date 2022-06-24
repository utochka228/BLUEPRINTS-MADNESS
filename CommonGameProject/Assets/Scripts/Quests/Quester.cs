using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestsSystem
{
    /// <summary>Quests manager for each level</summary>
    public class Quester : MonoBehaviour
    {
        public static Quester instance;
        public delegate void QuestReady(Quest levelQuest);
        public static event QuestReady OnLevelQuestReady;

        public delegate void QuestUpdates();
        public event QuestUpdates OnQuestUpdated;

        public delegate void StageChanged(StageQuest newStage);
        public static event StageChanged OnLevelStageChanged;

        private Quest LevelQuest;
        private Queue<StageQuest> StageQueue;

        private void Start()
        {
            if (LevelQuest != null)
                OnLevelQuestReady?.Invoke(LevelQuest);
        }

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
            OnLevelStageChanged?.Invoke(StageQueue.Peek());
            if (StageQueue.Count == 0)
            {
                Debug.Log("Level end!");
            }
        }
    }
}
