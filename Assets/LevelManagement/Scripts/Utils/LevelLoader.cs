using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LevelManagement
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private LoadingScreen loadingScreenPrefab;

        private float beforeLoadDelay = 0.5f;
        private float afterLoadDelay = 0.3f;

        //public float BeforeLoadDelay { get { return beforeLoadDelay; } }
        //public float AfterLoadDelay { get { return afterLoadDelay; } }

        #region Singleton
        private static LevelLoader instance;
        public static LevelLoader Instance { get { return instance; } }

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
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

        private IEnumerator LoadAsynchronously(int levelIndex)
        {
            LoadingScreen loadingScreenInstance = Instantiate(loadingScreenPrefab);

            yield return new WaitForSeconds(beforeLoadDelay); // Искусственное замедление загрузки
            
            AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
            
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);
                loadingScreenInstance.Fill.fillAmount = progress;
                loadingScreenInstance.StatusText.text = $"{(int)progress * 100}%";

                yield return null;
            }

            yield return new WaitForSeconds(afterLoadDelay); // Искусственное замедление загрузки
            Destroy(loadingScreenInstance.gameObject);
        }

        public void ReloadLevel()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            LoadLevel(currentScene.buildIndex);
        }

        public void LoadNextLevel()
        {
            int levelsNumber = SceneManager.sceneCountInBuildSettings;
            Scene level = SceneManager.GetActiveScene();
            int nextLevelIndex = (level.buildIndex + 1) % levelsNumber;
            LoadLevel(nextLevelIndex);
        }

        public void LoadLevel(int levelIndex)
        {
            if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
            {
                if (levelIndex == (int)SceneIndexes.MAIN_MENU)
                {
                    MainMenu.Open();
                }
                else if (levelIndex == (int)SceneIndexes.LEVEL_MAP_MENU)
                {
                    LevelMapMenu.Open();
                }

                // NEW ---------------------

                // NEW_END ---------------------

                //SceneManager.LoadScene(levelIndex);

                StartCoroutine(LoadAsynchronously(levelIndex));
            }
            else
            {
                Debug.LogWarning("LEVELLOADER LoadLevel Error: invalid scene specified!");
            }
        }

        public void LoadMainMenuLevel()
        {
            LoadLevel((int)SceneIndexes.MAIN_MENU);
        }

        public void LoadLevelMap()
        {
            LoadLevel((int)SceneIndexes.LEVEL_MAP_MENU);
        }
    }
}

