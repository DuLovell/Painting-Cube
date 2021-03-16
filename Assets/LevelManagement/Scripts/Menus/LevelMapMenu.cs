using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LevelManagement.Data;

namespace LevelManagement
{
    public class LevelMapMenu : Menu<LevelMapMenu>
    {
        [SerializeField] private List<GameObject> levelLockedImages;

        private void OnEnable()
        {
            Dictionary<int, LevelData> playerData = SaveLoadSystem.LoadPlayerData().levelsData;
            GameObject levelLockedImage;

            foreach (int levelId in playerData.Keys)
            {
                levelLockedImage = levelLockedImages[levelId];

                EnableLevelButton(levelLockedImage);
            }

            // Enabling first incompleted level
            levelLockedImage = levelLockedImages[SaveLoadSystem.LoadLastCompletedLevelData().id + 1];
            EnableLevelButton(levelLockedImage);

        }

        private static void EnableLevelButton(GameObject levelLockedImage)
        {
            // Deactivate Locked Image
            levelLockedImage?.SetActive(false);

            // Activate level button
            Button levelButton = levelLockedImage?.GetComponentInParent<Button>();
            levelButton.interactable = true;
        }

        #region Buttons
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
        #endregion
    }
}

