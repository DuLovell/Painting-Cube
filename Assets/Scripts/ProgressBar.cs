using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    Image fillImage;

    public void AddPoints()
    {
        slider.value++;
        if (slider.maxValue == slider.value)
            GameManager.Instance.OnLevelEnd();
    }

    public void TakeAwayPoints()
    {
        slider.value--;
    }

    private void Awake()
    {
        fillImage = GameObject.Find("Fill").GetComponent<Image>();
    }

    private void Start()
    {
        fillImage.color = Color.green;
        slider.maxValue = GameManager.Instance.plaformsNumber;
    }
}
