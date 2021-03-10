using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement
{
    public class PauseMenu : Menu<PauseMenu>
    {
        #region Methods

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

        public void OnMainMenuPressed()
        {
            Time.timeScale = 1;
            LevelLoader.Instance.LoadMainMenuLevel();
        } 
        #endregion
    }
}

