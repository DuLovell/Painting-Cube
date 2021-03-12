using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace LevelManagement.Data
{
    public static class SaveLoadSystem
    {
        public static void SaveLevelData(LevelData level)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Path.Combine(Application.persistentDataPath, "playerData.fun");
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData(level);

            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static LevelData LoadLevelData(int levelId)
        {
            string path = Path.Combine(Application.persistentDataPath, "playerData.fun");

            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                PlayerData data = formatter.Deserialize(stream) as PlayerData;

                Debug.Log(levelId);
                LevelData levelData = data.levelsData[levelId];

                return levelData;
            }
            else
            {
                Debug.LogError("Save file not found in " + path);
                return null;
            }


        }
    }
}

