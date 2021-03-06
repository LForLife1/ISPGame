using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignWithQuest : MonoBehaviour
{

    public SignalSender contextOn;
    public SignalSender contextOff;
    public SignalSender audioPlay;
    public GameObject dialogBox;
    public TMP_Text dialogText;
    public Sprite dialogImageSpriteHead;

    public bool givingItems;

    public int numDialogToUse;
    public string dialog;
    public string dialog2;
    public string dialog3;
    public string giveQuestDialog;
    bool questHasBeenGiven;
    public string duringQuestDialog;
    bool questCompleted;
    public bool postQuestDialogSaid;
    public string postQuestDialog;

    public bool playerInRange;

    public PlayerInventory playerInventory;
    public InventoryItem itemCheckingFor;
    public InventoryItem rewardItem;

    public InventoryItem workSquadSlips;

    public QuestGiver questGiver;
    public SignalSender bettenQuestSenderT;
    public SignalSender bettenQuestSenderF;

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
            //GiveTheQuest
            questGiver.GiveQuest();
            bettenQuestSenderT.Raise();
            //If giving item for quest, do it here
            if (givingItems)
            {
                playerInventory.myInventory.Add(workSquadSlips);
                workSquadSlips.numberHeld += 4;
            }
            questHasBeenGiven = true;
            return giveQuestDialog;

        } else if(questHasBeenGiven && !questCompleted)
        {
            return duringQuestDialog;

        }else if (!postQuestDialogSaid)
        {
            CompleteQuestDialog();
            bettenQuestSenderF.Raise();
            postQuestDialogSaid = true;
            return postQuestDialog;

        }else
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
        if (itemCheckingFor.numberHeld == 0)
        {
            return true;
        }
        return false;
    }

    void CompleteQuestVisual()
    {
        questGiver.quest.Complete();
        questGiver.questCompleted = true;
    }

    void CompleteQuestDialog()
    {
        playerInventory.myInventory.Add(rewardItem);
        rewardItem.numberHeld ++;
    }
}
