using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1Checker : MonoBehaviour
{
    //NEED AN INVENTORYREFERENCE
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
        //UPDATE CURRENT AMOUNT TO AMOUNT IN INVENTORY

    }

}
