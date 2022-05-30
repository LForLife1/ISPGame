using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCSign : MonoBehaviour
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
    [SerializeField] string questDialog;
    public static bool bettenQuestActive;
    public bool playerInRange;

    bool takenItem;
    public InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        bettenQuestActive = false;
        takenItem = false;
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
        if (bettenQuestActive)
        {
            if (!takenItem)
            {
                for (int i = 0; i < inventoryManager.playerInventory.myInventory.Count; i++)
                {
                    if (inventoryManager.playerInventory.myInventory[i].itemName.Equals("WorkSquadSlip"))
                    {
                        inventoryManager.playerInventory.myInventory[i].numberHeld -= 1;
                    }
                }
                takenItem = true;
            }         
            return questDialog;
        }
        else
        {
            int dialogToSay = Random.Range(1, numDialogToUse + 1);
            if (dialogToSay == 1)
            {
                return dialog;
            }
            else if (dialogToSay == 2)
            {
                return dialog2;
            }
            else
            {
                return dialog3;
            }
        }
    }

    public void changeBettenQuestStatusTrue()
    {
        bettenQuestActive = true;
    }

    public void changeBettenQuestStatusFalse()
    {
        bettenQuestActive = false;
    }

}
