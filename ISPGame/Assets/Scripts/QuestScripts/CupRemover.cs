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
            Debug.Log("this worked");
            for (int i = 0; i < inventoryManager.playerInventory.myInventory.Count; i++)
            {
                if (inventoryManager.playerInventory.myInventory[i].itemName.Equals("Plastic Cup"))
                {
                    Debug.Log("works as intended");
                    inventoryManager.playerInventory.myInventory[i].numberHeld = 0;
                    //inventoryManager.playerInventory
                }
            }
        }
    }
}
