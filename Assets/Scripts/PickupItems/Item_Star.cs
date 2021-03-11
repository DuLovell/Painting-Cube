using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Star : PickupItem
{
    protected override void OnPickup()
    {
        GameManager.Instance.StarsCollected++;
    }
}
