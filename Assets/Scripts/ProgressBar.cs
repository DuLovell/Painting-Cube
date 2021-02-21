using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Slider slider;

    public void SetMaxPlatforms(int platformsNumber)
    {
        slider.maxValue = platformsNumber;
    }

    public void SetPlatform()
    {
        slider.value++;
    }

    private void OnEnable()
    {
        // подписаться на ивент
        EventManager.Instance.onPlatformColorChange += SetPlatform;
    }

    private void OnDisable()
    {
        // отписаться от ивента
        EventManager.Instance.onPlatformColorChange -= SetPlatform;
    }
}
