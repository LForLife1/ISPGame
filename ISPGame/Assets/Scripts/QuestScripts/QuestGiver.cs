using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public QuestInventory questInventory;
    public bool questCompleted;
    public MainCharScript mainCharacter;

    public GameObject roomTransfer;
    public GameObject roomBlocker;

    public void Start()
    {
        roomBlocker.SetActive(true);
        roomTransfer.SetActive(false);
        questCompleted = false;
    }

    public void OnQuestComplete()
    {
        roomBlocker.SetActive(false);
        roomTransfer.SetActive(true);
    }

    public void GiveQuest()
    {
        if (questInventory && quest)
        {
            questInventory.myQuests.Add(quest);
            quest.isActive = true;
        }
    }
}
