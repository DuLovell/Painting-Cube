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
            LevelLoader.Instance.LoadNextLevel();
        }

        public void OnRestartPressed()
        {
            LevelLoader.Instance.ReloadLevel();
            base.OnBackPressed();
        }

        public void OnMainMenuPressed()
        {
            LevelLoader.Instance.LoadMainMenuLevel();
        }
    }
}

