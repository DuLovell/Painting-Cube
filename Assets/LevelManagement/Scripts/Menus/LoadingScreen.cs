using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace LevelManagement
{
    [RequireComponent(typeof(DontDestroyOnLoad))]
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Image fillImage;
        [SerializeField] private Text statusText;

        //private bool isWaiting;

        public Image Fill { get { return fillImage; } }
        public Text StatusText { get { return statusText; } }

        //private void Update()
        //{
        //    if (!isWaiting && fillImage.fillAmount == 1)
        //    {
        //        isWaiting = true;

        //        Time.timeScale = 0;
        //    }

        //    if (isWaiting && (Keyboard.current.anyKey.wasPressedThisFrame))
        //    {
        //        Time.timeScale = 1;
        //        Destroy(gameObject);
        //    }
        //}
    }
}

