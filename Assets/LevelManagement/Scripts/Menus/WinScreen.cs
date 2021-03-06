using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public class WinScreen : Menu<WinScreen>
    {
        public void OnNextPressed()
        {
            base.OnBackPressed();
            LevelLoader.LoadNextLevel();
        }

        public void OnRestartPressed()
        {
            LevelLoader.ReloadLevel();
            base.OnBackPressed();
        }

        public void OnMainMenuPressed()
        {
            LevelLoader.LoadMainMenuLevel();
        }
    }
}

