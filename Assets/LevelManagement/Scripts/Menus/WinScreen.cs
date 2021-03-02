using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public class WinScreen : Menu<WinScreen>
    {
        public void OnNextPressed()
        {
            LevelLoader.LoadNextLevel();
            base.OnBackPressed();
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

