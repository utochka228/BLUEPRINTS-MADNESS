using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Resources;
using Items;

namespace QuestsSystem
{
    [CreateAssetMenu(fileName = "Simple goal", menuName = "Quest goal/Create simple goal")]
    public class TaskGoal : ScriptableObject
    {
        public List<ResourcesGoal> ResourcesGoals;
        public List<ItemsGoal> ItemsGoals;
        public List<string> ActionNamesGoals;
    }

    [System.Serializable]
    public struct ResourcesGoal
    {
        public Resource resource;
        public int count;
    }
    [System.Serializable]
    public struct ItemsGoal
    {
        public Item item;
        public int count;
    }
}
