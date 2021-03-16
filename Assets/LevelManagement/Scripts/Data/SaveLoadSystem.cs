using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace LevelManagement.Data
{
    public static class SaveLoadSystem
    {
        private static void ReadPlayerData(string path, out FileStream stream, out PlayerData data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            stream = new FileStream(path, FileMode.Open);

            data = formatter.Deserialize(stream) as PlayerData;
        }

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

            data.SaveData(level);

            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static PlayerData LoadPlayerData()
        {
            string path = Path.Combine(Application.persistentDataPath, "playerData.fun");

            if (File.Exists(path))
            {
                FileStream stream;
                PlayerData data;

                ReadPlayerData(path, out stream, out data);

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
                FileStream stream;
                PlayerData data;

                ReadPlayerData(path, out stream, out data);

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

        public static LevelData LoadLastCompletedLevelData()
        {
            string path = Path.Combine(Application.persistentDataPath, "playerData.fun");

            if (File.Exists(path))
            {
                FileStream stream;
                PlayerData data;

                ReadPlayerData(path, out stream, out data);

                List<int> dataKeys = data.levelsData.Keys.ToList();
                int levelId = dataKeys.Max();

                LevelData levelData = data.levelsData[levelId];
                


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

