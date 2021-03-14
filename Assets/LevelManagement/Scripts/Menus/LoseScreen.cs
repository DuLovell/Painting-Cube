using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement
{
    public class LoseScreen : StarMenu<LoseScreen>
    {
        [SerializeField] private Text levelIdText;

        protected override void OnEnable()
        {
            base.OnEnable();
            levelIdText.text = $"Level: {GameManager.Instance?.LevelId}";
        }

        #region Buttons (public)
        public void OnLevelMapPressed()
        {
            base.OnBackPressed();
            LevelLoader.Instance.LoadLevelMap();
        }

        public void OnRestartPressed()
        {
            base.OnBackPressed();
            LevelLoader.Instance.ReloadLevel();
        }

        public void OnLeaderboardPressed()
        {
        } 
        #endregion
    }
}

