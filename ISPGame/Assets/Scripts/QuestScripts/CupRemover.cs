using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupRemover : MonoBehaviour
{

    [SerializeField] InventoryManager inventoryManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < inventoryManager.playerInventory.myInventory.Count; i++)
            {
                if (inventoryManager.playerInventory.myInventory[i].itemName.Equals("Plastic Cup"))
                {
                    inventoryManager.playerInventory.myInventory[i].numberHeld = 0;
                }
            }
        }
    }
}
