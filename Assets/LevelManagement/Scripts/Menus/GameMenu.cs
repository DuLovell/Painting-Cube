using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement
{
    public class GameMenu : Menu<GameMenu>
    {
        [SerializeField] private Text groundCellsText;
        [SerializeField] private Text grassCellsText;

        public void OnPausePressed()
        {
            Time.timeScale = 0;

            // disable player controls
            Player_Movement playerControls = GameObject.FindObjectOfType<Player_Movement>();

            if (playerControls != null)
            {
                playerControls.enabled = false;
            }

            PauseMenu.Open();
        }

        public void RefreshCounters()
        {
            groundCellsText.text = $"{GameManager.Instance.CurrentGroundCells}/{GameManager.Instance.TotalGroundCells}";
            grassCellsText.text = $"{GameManager.Instance.CurrentGrassCells}/{GameManager.Instance.TotalGrassCells}";
        }
    }
}

