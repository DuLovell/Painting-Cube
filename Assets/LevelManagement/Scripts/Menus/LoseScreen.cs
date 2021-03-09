using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public class LoseScreen : Menu<LoseScreen>
    {
        public void OnMainMenuPressed()
        {
            base.OnBackPressed();
            LevelLoader.LoadMainMenuLevel();
        }

        public void OnRestartPressed()
        {
            base.OnBackPressed();
            LevelLoader.ReloadLevel();
        }

        public void OnLeaderboardPressed()
        {
        }
    }
}

