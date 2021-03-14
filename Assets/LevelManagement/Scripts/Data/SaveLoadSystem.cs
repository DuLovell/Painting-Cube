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
            PlayerData data = LoadPlayerData();

            BinaryFormatter formatter = new BinaryFormatter();
            string path = Path.Combine(Application.persistentDataPath, "playerData.fun");
            FileStream stream = new FileStream(path, FileMode.Create);

            if (data == null)
            {
                data = new PlayerData();
            }

            data.UpdateData(level);

            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static PlayerData LoadPlayerData()
        {
            string path = Path.Combine(Application.persistentDataPath, "playerData.fun");

            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                PlayerData data = formatter.Deserialize(stream) as PlayerData;

                stream.Close();
                return data;
            }
            else
            {
                Debug.LogError("Save file not found in " + path);
                return null;
            }
        }

        public static LevelData LoadLevelData(int levelId)
        {
            string path = Path.Combine(Application.persistentDataPath, "playerData.fun");

            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                PlayerData data = formatter.Deserialize(stream) as PlayerData;

                LevelData levelData = null;
                if (data.levelsData.ContainsKey(levelId))
                {
                    levelData = data.levelsData[levelId];
                }
                

                stream.Close();
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

