using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    private static int secondsSinceStart;
    private static int minutesSinceStart;

    public static int SecondsSinceStart { get { return secondsSinceStart; } }
    public static int MinutesSinceStart { get { return minutesSinceStart; } }

    private void Update()
    {
        secondsSinceStart = (int)Time.timeSinceLevelLoad % 60;
        minutesSinceStart = (int)Time.timeSinceLevelLoad / 60;
    }
}
