using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{

    [Header("Inventory Information")]
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI descriptionText;
    public InventoryItem currentItem;

    void OnEnable()
    {
        ClearInventorySlots();
        MakeInventorySlots();
        SetText("");
    }

    public void SetText(string description)
    {
        descriptionText.text = description;
    }

    void MakeInventorySlots()
    {
        if (playerInventory)
        {
            for(int i = 0; i < playerInventory.myInventory.Count; i++)
            {
                if(playerInventory.myInventory[i].numberHeld > 0)
                {
                    GameObject temp = Instantiate(blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                    temp.transform.SetParent(inventoryPanel.transform);

                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                    if (newSlot)
                    {
                        newSlot.Setup(playerInventory.myInventory[i], this);

                    }
                }
            }
        }
    }

    public void SetupDescription(string newDescription, InventoryItem newItem)
    {
        currentItem = newItem;
        descriptionText.text = newDescription;
    }

    void ClearInventorySlots()
    {
        for(int i = 0; i < inventoryPanel.transform.childCount; i++)
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }

    public void interactButtonPressed()
    {
        if (currentItem)
        {
            currentItem.Use();
            ClearInventorySlots();
            MakeInventorySlots();
        }
    }

    public void resetInventory()
    {
        for (int i = 0; i < playerInventory.myInventory.Count; i++)
        {
            playerInventory.myInventory[i].numberHeld = 0;
        }

        playerInventory.myInventory.Clear();
    }
}
