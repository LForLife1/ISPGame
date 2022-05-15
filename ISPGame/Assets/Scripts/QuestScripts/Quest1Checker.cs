using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1Checker : MonoBehaviour
{

    public InventoryObject inventory;
    public QuestGiver questGiver;
    QuestGoal questGoal;

    int currentAmount;

    void Start()
    {
        questGoal = questGiver.quest.questGoal;
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (inventory.Container[i].ID == 0 && currentAmount != inventory.Container[i].amount)
            {
                questGoal.currentAmount = inventory.Container[i].amount;
                currentAmount = inventory.Container[i].amount;

            }
        }
    }

}
