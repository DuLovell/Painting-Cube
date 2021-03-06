using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class LevelLoader
    {
        private static int mainMenuIndex = 0;

        public static void ReloadLevel()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            LoadLevel(currentScene.buildIndex);
        }

        public static void LoadNextLevel()
        {
            int levelsNumber = SceneManager.sceneCountInBuildSettings;
            Scene level = SceneManager.GetActiveScene();
            int nextLevelIndex = (level.buildIndex + 1) % levelsNumber;
            LoadLevel(nextLevelIndex);
        }

        public static void LoadLevel(int levelIndex)
        {
            if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
            {
                if (levelIndex == mainMenuIndex)
                {
                    MainMenu.Open();
                }

                SceneManager.LoadScene(levelIndex);
            }
            else
            {
                Debug.LogWarning("LEVELLOADER LoadLevel Error: invalid scene specified!");
            }
        }

        public static void LoadMainMenuLevel()
        {
            LoadLevel(mainMenuIndex);
        }
    }
}

