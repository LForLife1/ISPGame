using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAdder : MonoBehaviour
{
    [SerializeField] private QuestInventory questInventory;
    [SerializeField] private Quest thisQuest;

    void AddQuest()
    {
        if (questInventory && thisQuest)
        {
            questInventory.myQuests.Add(thisQuest);
        }
    }
}
