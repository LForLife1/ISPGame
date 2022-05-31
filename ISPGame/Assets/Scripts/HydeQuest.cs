using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HydeQuest : MonoBehaviour
{

    //Normal InteractionStuff
    public SignalSender contextOn;
    public SignalSender contextOff;
    public SignalSender audioPlay;
    public GameObject dialogBox;
    public TMP_Text dialogText;
    public Sprite dialogImageSpriteHead;
    public bool playerInRange;

    //NormalDialogStuff
    public int numDialogToUse;
    public string dialog;
    public string dialog2;
    public string dialog3;
    public string giveQuestDialog;
    bool questHasBeenGiven;
    public string duringQuestDialog;
    bool questCompleted;
    public string postQuestDialog;
    bool postQuestDialogSaid;

    //InventoryCheckStuff
    public PlayerInventory playerInventory;
    public InventoryItem itemLookingFor;
    public InventoryItem itemLookingFor2;
    public InventoryItem itemToGive;

    //QuestSpecificStuff
    public QuestGiver questGiver;

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

        if (questHasBeenGiven && CheckItems())
        {
            questCompleted = true;
            CompleteQuestVisual();
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
        if (!questHasBeenGiven)
        {
            questGiver.GiveQuest();
            questHasBeenGiven = true;
            return giveQuestDialog;

        }
        else if (questHasBeenGiven && !questCompleted)
        {
            return duringQuestDialog;

        }
        else if (!postQuestDialogSaid)
        {
            CompleteQuestDialog();
            postQuestDialogSaid = true;
            return postQuestDialog;
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

    bool CheckItems()
    {
        bool part1 = false;
        bool part2 = false;

        for (int i = 0; i < playerInventory.myInventory.Count; i++)
        {
            if (playerInventory.myInventory[i].itemName.Equals("Test Tube"))
            {
                if (playerInventory.myInventory[i].numberHeld >= questGiver.quest.questGoal.requiredAmount)
                {
                    part1 = true;
                }
            }

            if (playerInventory.myInventory[i].itemName.Equals("Missing Gas Mask") && playerInventory.myInventory[i].numberHeld > 0)
            {
                part2 = true;
            }
               
        }
        return (part1 && part2);
    }

    void CompleteQuestVisual()
    {
        questGiver.quest.Complete();
        questGiver.questCompleted = true;
    }

    void CompleteQuestDialog()
    {
        playerInventory.myInventory.Add(itemToGive);
        itemToGive.numberHeld = 1;

        for (int i = 0; i < playerInventory.myInventory.Count; i++)
        {
            if (playerInventory.myInventory[i].itemName.Equals("Test Tube"))
            {
                playerInventory.myInventory[i].numberHeld -= questGiver.quest.questGoal.requiredAmount;
            }

            if (playerInventory.myInventory[i].itemName.Equals("Missing Gas Mask"))
            {
                playerInventory.myInventory[i].numberHeld --;
            }
        }
    }
}