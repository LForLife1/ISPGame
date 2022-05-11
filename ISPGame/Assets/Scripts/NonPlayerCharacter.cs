using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public string charName;
    public QuestGiver questGiver;
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    float timerDisplay;

    public GameObject unsaidTextSprite;
    public GameObject hasQuestSprite;
    bool hasSaidThing;
    bool displayingQuest;

    void Start()
    {
        displayingQuest = false;
        hasSaidThing = false;
        unsaidTextSprite.SetActive(true);
        hasQuestSprite.SetActive(false);
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
    }

    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }

        if(displayingQuest == !questGiver.quest.isActive)
        {
            hasQuestSprite.SetActive(false);
            displayingQuest = false;
        }

        if (!displayingQuest == questGiver.quest.isActive)
        {
            hasQuestSprite.SetActive(true);
            displayingQuest = true;
        }

        if(questGiver.quest.isActive && questGiver.quest.questGoal.IsReached())
        {
            questGiver.quest.Complete();
            questGiver.OnQuestCompleteShowCheck();
        }

    }

    public void giveQuest1()
    {
        questGiver.OpenQuestWindow();
        displayingQuest = true;
        hasQuestSprite.SetActive(true);
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);

        if(!hasSaidThing)
        {
            unsaidTextSprite.SetActive(false);
            hasSaidThing = true;
        }
    }
}