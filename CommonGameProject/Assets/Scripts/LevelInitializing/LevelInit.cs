using Building;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Initialization
{
    public enum LevelKind { ForestHouse, School}
    public class LevelInit : MonoBehaviour
    {
        [SerializeField] LevelKind levelKind;
        [SerializeField] Construction levelConstruction;
        private void Start()
        {
            InitLevel();
        }

        private void InitLevel()
        {
            SetLevelBuilder();
            // Set another stuff
        }

        private void SetLevelBuilder()
        {
            switch (levelKind)
            {
                case LevelKind.ForestHouse:
                    levelConstruction.SetDirector(new ForestHouseDirector());
                    break;
                case LevelKind.School:
                    levelConstruction.SetDirector(new SchoolDirector());
                    break;
            }
        }
    }
}
