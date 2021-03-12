using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public class LevelMapMenu : Menu<LevelMapMenu>
    {
        public void OnLevelPressed(int levelId)
        {
            LevelMenu.Instance.LevelId = levelId;
            LevelMenu.Open();
        }

        public void OnMainMenuPressed()
        {
            base.OnBackPressed();
            LevelLoader.Instance.LoadMainMenuLevel();
        }
    }
}

