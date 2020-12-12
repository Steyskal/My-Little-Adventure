using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public Item TreasureItem;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

        if (playerController == null)
            return;

        Item treasureItemClone = Instantiate(TreasureItem);

        bool wasTreasureItemAdded = playerController.PlayerInventory.AddItem(treasureItemClone);

        if(wasTreasureItemAdded)
            Destroy(gameObject);
    }
}
