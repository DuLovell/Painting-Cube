using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private Image fillImage;

    private void Awake()
    {
        fillImage = GameObject.Find("Fill").GetComponent<Image>();
    }

    private void Start()
    {
        fillImage.color = Color.green;
        slider.maxValue = GameManager.Instance.plaformsNumber;
    }

    private void Update()
    {
        if (GameManager.Instance != null && slider != null)
        {
            slider.value = GameManager.Instance.totalPoints;
        }
    }
}
