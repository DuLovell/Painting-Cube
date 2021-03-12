using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Missions
{
    [CreateAssetMenu(fileName = "Missions", menuName = "Missions/Create Missions list", order = 1)]
    public class MissionList : ScriptableObject
    {
        [SerializeField] private List<MissionSpecs> missions;

        public int TotalMissions => missions.Count;

        public MissionSpecs GetMission(int index)
        {
            return missions[index];
        }
    }
}

