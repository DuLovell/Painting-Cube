using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    Image fillImage;

    public void SetPlatform()
    {
        slider.value++;
    }

    private void Awake()
    {
        fillImage = GameObject.Find("Fill").GetComponent<Image>();
    }

    private void Start()
    {
        fillImage.color = LevelManager.Instance.winColor;
        slider.maxValue = LevelManager.Instance.plaformsNumber;

        EventManager.Instance.onPlatformWinColorChange += SetPlatform;
    }

    private void OnDisable()
    {
        EventManager.Instance.onPlatformWinColorChange -= SetPlatform;
    }
}
