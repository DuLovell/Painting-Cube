using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement
{
    public class WinScreen : StarMenu<WinScreen>
    {
        [SerializeField] private Text levelIdText;

        protected override void OnEnable()
        {
            base.OnEnable();
            levelIdText.text = $"Level: {GameManager.Instance?.LevelId}";
        }

        #region Buttons (public)
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

        public void OnLevelMapPressed()
        {
            LevelLoader.Instance.LoadLevelMap();
        } 
        #endregion
    }
}

