using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestsSystem.UI
{
    public class QuestUI : MonoBehaviour
    {
        [SerializeField] RectTransform stagesGUIHolder;
        [SerializeField] RectTransform stageTasksGUIHolder;
        private void OnEnable()
        {
            Quester.OnLevelQuestReady += DrawQuestStagesGUI;
            Quester.OnLevelStageChanged += DrawStageTasksGUI;
        }
        private void OnDisable()
        {
            Quester.OnLevelQuestReady -= DrawQuestStagesGUI;
            Quester.OnLevelStageChanged -= DrawStageTasksGUI;
        }

        private void DrawQuestStagesGUI(Quest levelQuest)
        {
            var stages = levelQuest.TargetQuestObject.QuestStages;
            foreach (var stage in stages)
            {

            }
        }

        private void DrawStageTasksGUI(StageQuest stageQuest)
        {

        }
    }
}
