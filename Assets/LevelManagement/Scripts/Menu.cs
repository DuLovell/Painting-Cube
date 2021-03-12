using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement
{
    public abstract class Menu<T> : Menu where T: Menu<T>
    {
        [SerializeField] protected Text levelTimerText;
        [SerializeField] private GameObject[] stars = new GameObject[4];

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

            if (GameManager.Instance != null)
            {
                for (int starIndex = 0; starIndex < GameManager.Instance.StarsCollected; starIndex++)
                {
                    if (stars[starIndex] != null)
                    {
                        stars[starIndex].SetActive(true);
                    }
                }
            }
            
        }

        private void OnDisable()
        {
            if (GameManager.Instance != null)
            {
                for (int starIndex = 0; starIndex < GameManager.Instance.StarsCollected; starIndex++)
                {
                    if (stars[starIndex] != null)
                    {
                        stars[starIndex].SetActive(false);
                    }
                }
            }
            
        }

        public static void Open(int levelId = -1)
        {
            if (MenuManager.Instance != null && instance != null)
            {
                if (levelId >= 0)
                {

                }

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

