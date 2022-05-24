using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1Checker : MonoBehaviour
{
    [SerializeField] InventoryItem inventoryItem;
    public QuestGiver questGiver;

    // Update is called once per frame
    void Update()
    {
        if(inventoryItem.numberHeld != questGiver.quest.questGoal.currentAmount)
        {
            questGiver.quest.questGoal.currentAmount = inventoryItem.numberHeld;
        }

        if (questGiver.quest.questGoal.IsReached())
        {
            questGiver.quest.Complete();
            questGiver.OnQuestCompleteShowCheck();
            questGiver.questCompleted = true;
            inventoryItem.numberHeld = 0;
        }

    }

}
