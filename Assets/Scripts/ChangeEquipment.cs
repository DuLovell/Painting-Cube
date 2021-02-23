using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEquipment : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player.color == LevelManager.Instance.groundColor)
                player.color = LevelManager.Instance.seedsColor;    
            else
                player.color = LevelManager.Instance.groundColor;
        }
    }
}
