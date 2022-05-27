using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignWithItem : MonoBehaviour
{

    public SignalSender contextOn;
    public SignalSender contextOff;
    public SignalSender audioPlay;
    public GameObject dialogBox;
    public TMP_Text dialogText;
    public Sprite dialogImageSpriteHead;

    public int numDialogToUse;
    public string dialog;
    public string dialog2;
    public string dialog3;
    public bool playerInRange;

    public PlayerInventory playerInventory;
    public InventoryItem inventoryItem;

    bool itemCollected;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = chooseCorrectDialogue();
                dialogBox.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = dialogImageSpriteHead;
                audioPlay.Raise();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            contextOn.Raise();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
            contextOff.Raise();
        }
    }

    string chooseCorrectDialogue()
    {
        if (!itemCollected)
        {
            itemCollected = true;

            if (playerInventory.myInventory.Contains(inventoryItem))
            {
                inventoryItem.numberHeld++;
            }
            else
            {
                playerInventory.myInventory.Add(inventoryItem);
                inventoryItem.numberHeld += 1;
            }

            return dialog;
        } else
        {
            return dialog2;
        }
    }
}