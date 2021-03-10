﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement
{
    public abstract class Menu<T> : Menu where T: Menu<T>
    {
        [SerializeField] protected Text levelTimerText;

        #region Singleton
        private static T instance;
        public static T Instance { get { return instance; } }

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = (T)this;
            }
        }

        private void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        } 
        #endregion

        private void OnEnable()
        {
            if (levelTimerText != null)
            {
                levelTimerText.text = LevelTimer.MinutesSinceStart + ":" + LevelTimer.SecondsSinceStart.ToString("00");
            }
        }

        public static void Open()
        {
            if (MenuManager.Instance != null && instance != null)
            {
                MenuManager.Instance.OpenMenu(Instance);
            }
        }
    }

    [RequireComponent(typeof(Canvas))]
    public abstract class Menu : MonoBehaviour
    {
        public virtual void OnBackPressed()
        {
            MenuManager.Instance.CloseMenu();
        }
    }
}

