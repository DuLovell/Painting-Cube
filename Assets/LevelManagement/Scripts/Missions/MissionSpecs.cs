using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace LevelManagement.Missions
{
    [Serializable]
    public class MissionSpecs
    {
        #region FIELDS_INSPECTOR
        [SerializeField] protected string sceneName;
        [SerializeField] protected int id;
        [SerializeField] protected string[] objectives; 
        #endregion

        #region PROPERTIES
        public string SceneName => sceneName;
        public int Id => id;
        public string[] Objectives => objectives; 
        #endregion
    }
}

