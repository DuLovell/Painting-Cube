using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelManagement.Data;

namespace LevelManagement
{
    public class LevelMenu : Menu<LevelMenu>
    {
        [SerializeField] private GameObject newLevelCanvas;
        [SerializeField] private GameObject oldLevelCanvas;

        private int levelId;

        public int LevelId { set { levelId = value; } }

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

        public void SetScreen()
        {
            LevelData levelData = SaveLoadSystem.LoadLevelData(levelId);

            if (levelData != null)
            {
                if (levelTimerText != null)
                {
                    levelTimerText.text = levelData.minutesPassed + ":" + levelData.secondsPassed.ToString("00");
                }

                for (int starIndex = 0; starIndex < levelData.starsCollected; starIndex++)
                {
                    stars[starIndex]?.SetActive(true);
                }

                oldLevelCanvas.SetActive(true);
                newLevelCanvas.SetActive(false);
            }
            else
            {
                oldLevelCanvas.SetActive(false);
                newLevelCanvas.SetActive(true);
            }
        }
    }
}

