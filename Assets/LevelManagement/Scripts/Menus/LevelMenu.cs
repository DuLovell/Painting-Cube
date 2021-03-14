using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LevelManagement.Data;
using LevelManagement.Missions;

namespace LevelManagement
{
    public class LevelMenu : StarMenu<LevelMenu>
    {
        [SerializeField] private MissionList missionList;

        [SerializeField] private Text levelIdHeaderText;

        [SerializeField] private GameObject newLevelCanvas;
        [SerializeField] private Text objective1Text;
        [SerializeField] private Text objective2Text;

        [SerializeField] private GameObject oldLevelCanvas;

        private int levelId;

        public int LevelId { set { levelId = value; } }

        protected override void OnEnable()
        {
            base.OnEnable();
            SetCanvas();
        }

        #region Canvases (private)
        private void SetCanvas()
        {
            if (levelId <= 0) return;

            levelIdHeaderText.text = $"Level: {levelId}";

            LevelData levelData = SaveLoadSystem.LoadLevelData(levelId);

            if (levelData != null)
            {
                SetOldCanvas(levelData);
            }
            else
            {
                SetNewCanvas();
            }
        }

        private void SetNewCanvas()
        {
            MissionSpecs mission = missionList.GetMission(levelId);


            objective1Text.text = mission.Objectives[0];
            objective2Text.text = mission.Objectives[1];


            oldLevelCanvas.SetActive(false);
            newLevelCanvas.SetActive(true);
        }

        private void SetOldCanvas(LevelData levelData)
        {
            for (int starIndex = 0; starIndex < levelData.starsCollected; starIndex++)
            {
                stars[starIndex]?.SetActive(true);
            }

            levelTimerText.text = levelData.minutesPassed + ":" + levelData.secondsPassed.ToString("00");

            oldLevelCanvas.SetActive(true);
            newLevelCanvas.SetActive(false);
        }
        #endregion

        #region Buttons (public)
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
        #endregion


    }
}

