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

    public int numDialogToUse;
    public string dialog;
    public string dialog2;
    public string dialog3;
    public string giveQuestDialog;
    bool questHasBeenGiven;
    public string duringQuestDialog;
    bool questCompleted;
    bool postQuestDialogSaid;
    public string postQuestDialog;

    public bool playerInRange;

    public PlayerInventory playerInventory;
    public InventoryItem attendanceSheet1;
    public InventoryItem attendanceSheet2;
    public InventoryItem attendanceSheet3;
    public InventoryItem attendanceSheet4;

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
        if (!questHasBeenGiven)
        {
            //GiveTheQuest
            //If giving item for quest, do it here
            playerInventory.myInventory.Add(attendanceSheet1);
            attendanceSheet1.numberHeld += 1;
            playerInventory.myInventory.Add(attendanceSheet2);
            attendanceSheet2.numberHeld += 1;
            playerInventory.myInventory.Add(attendanceSheet3);
            attendanceSheet3.numberHeld += 1;
            playerInventory.myInventory.Add(attendanceSheet4);
            attendanceSheet4.numberHeld += 1;

            questHasBeenGiven = true;
            return giveQuestDialog;

        } else if(questHasBeenGiven && !questCompleted)
        {
            return duringQuestDialog;

        }else if (!postQuestDialogSaid)
        {
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
}
