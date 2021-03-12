using System.Collections;
using System.Collections.Generic;
using System;

namespace LevelManagement.Data
{
    [Serializable]
    public class LevelData
    {
        public int id;

        public bool isCompleted;

        public int starsCollected;

        public int secondsPassed;
        public int minutesPassed;

        public LevelData(int levelId, bool isCompleted, int starsCollected, int secondsPassed, int minutesPassed)
        {
            this.id = levelId;
            this.isCompleted = isCompleted;
            this.starsCollected = starsCollected;
            this.secondsPassed = secondsPassed;
            this.minutesPassed = minutesPassed;
        }
    }

    [Serializable]
    public class PlayerData
    {
        public Dictionary<int, LevelData> levelsData = new Dictionary<int, LevelData>(); // информация о каждом уровне

        private void CompareLevelData(LevelData level)
        {
            LevelData oldLevelData = levelsData[level.id];

            if (level.isCompleted)
            {
                if (level.starsCollected > oldLevelData.starsCollected)
                {
                    levelsData[level.id].starsCollected = level.starsCollected;

                    levelsData[level.id].minutesPassed = level.minutesPassed;
                    levelsData[level.id].secondsPassed = level.secondsPassed;
                }     
            }
        }

        public PlayerData(LevelData level)
        {
            if (levelsData.ContainsKey(level.id))
            {
                CompareLevelData(level);
            }
            else
            {
                levelsData.Add(level.id, level);
            }
        }

        
    }
}

