using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEquipment : MonoBehaviour
{
    [field: SerializeField] public Color grassCutter { get; private set; }
    [field: SerializeField] public Color seedsColor { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player.color == grassCutter)
                player.color = seedsColor;    
            else
                player.color = grassCutter;
        }
    }
}
