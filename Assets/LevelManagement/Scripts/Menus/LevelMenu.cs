using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public class LevelMenu : Menu<LevelMenu>
    {
        
        private int levelId;

        public int LevelId { set { levelId = value; } }


        // override enable method to load level specific data


        public void OnPlayPressed(int levelIndex)
        {
            LevelLoader.Instance.LoadLevel(levelIndex);

            GameMenu.Open();
        }

        public void OnMainMenuPressed()
        {
            LevelLoader.Instance.LoadMainMenuLevel();
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }
    }
}

