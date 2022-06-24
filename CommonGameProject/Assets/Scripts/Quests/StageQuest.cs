using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestsSystem
{
    [System.Serializable]
    public class StageQuest
    {
        public string StageName;
        public Sprite StageIcon;
        public List<Task> StageQuests;
    }
    [System.Serializable]
    public struct Task
    {
        public string TaskTitle;
        public string TaskDescription;
        public TaskGoal Goal;
    }
}
