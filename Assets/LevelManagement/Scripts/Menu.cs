using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement
{
    public abstract class StarMenu<T> : Menu<T> where T : StarMenu<T>
    {
        [SerializeField] protected Text levelTimerText;
        [SerializeField] protected GameObject[] stars = new GameObject[4];

        protected virtual void OnEnable()
        {
            if (levelTimerText != null)
            {
                levelTimerText.text = LevelTimer.MinutesSinceStart + ":" + LevelTimer.SecondsSinceStart.ToString("00");
            }

            SetActiveStars(true);

        }

        protected virtual void OnDisable()
        {
            SetActiveStars(false);
        }

        private void SetActiveStars(bool mode)
        {
            if (GameManager.Instance != null)
            {
                for (int starIndex = 0; starIndex < GameManager.Instance.StarsCollected; starIndex++)
                {
                    if (stars[starIndex] != null)
                    {
                        stars[starIndex].SetActive(mode);
                    }
                }
            }
        }
    }    

    public abstract class Menu<T> : Menu where T : Menu<T>
    {
        

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

        

        public static void Open(int levelId = -1)
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

