using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Image fillImage;
        [SerializeField] private Text statusText;

        public Image Fill { get { return fillImage; } }
        public Text StatusText { get { return statusText; } }
    }
}

