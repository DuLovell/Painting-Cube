using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement
{
    public class PauseMenu : StarMenu<PauseMenu>
    {
        [SerializeField] private Text levelIdText;

        protected override void OnEnable()
        {
            base.OnEnable();
            levelIdText.text = $"Level: {GameManager.Instance?.LevelId}";
        }

        #region Buttons (public)

        public void OnResumePressed()
        {
            Time.timeScale = 1;

            // enable player controls
            Player_Movement playerControls = GameObject.FindObjectOfType<Player_Movement>();

            if (playerControls != null)
            {
                playerControls.enabled = true;
            }

            base.OnBackPressed();
        }

        public void OnRestartPressed()
        {
            Time.timeScale = 1;
            LevelLoader.Instance.ReloadLevel();
            base.OnBackPressed();
        }

        public void OnLevelMapPressed()
        {
            Time.timeScale = 1;
            LevelLoader.Instance.LoadLevelMap();
        } 
        #endregion
    }
}

