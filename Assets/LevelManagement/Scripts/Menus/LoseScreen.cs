using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public class LoseScreen : Menu<LoseScreen>
    {
        public void OnLevelMapPressed()
        {
            base.OnBackPressed();
            LevelLoader.Instance.LoadLevelMap();
        }

        public void OnRestartPressed()
        {
            base.OnBackPressed();
            LevelLoader.Instance.ReloadLevel();
        }

        public void OnLeaderboardPressed()
        {
        }
    }
}

