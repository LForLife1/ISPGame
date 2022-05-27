using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public bool questCompleted;
    public MainCharScript mainCharacter;

    public GameObject questHub;
    public GameObject roomTransfer;
    public GameObject roomBlocker;

    public TMP_Text titleText;
    public TMP_Text descriptionText;
    //public Text dialogRewardText;

    public void Start()
    {
        questHub.SetActive(false);
        roomBlocker.SetActive(true);
        roomTransfer.SetActive(false);
        questCompleted = false;
    }

    public void OpenQuestWindow()
    {
        questHub.SetActive(true);
        questHub.transform.Find("CompletionImage").gameObject.SetActive(false);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        //dialogRewardText.text = quest.dialogReward;

        quest.isActive = true;
        mainCharacter.quest = quest;
    }

    public void OnQuestCompleteShowCheck()
    {
        questHub.transform.Find("CompletionImage").gameObject.SetActive(true);
        Debug.Log("The door is unlocked");
        roomBlocker.SetActive(false);
        roomTransfer.SetActive(true);
    }
}
