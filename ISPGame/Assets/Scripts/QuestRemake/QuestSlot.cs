using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestSlot : MonoBehaviour
{
    [Header("UI Stuff to change")]
    [SerializeField] private TextMeshProUGUI questTitle;
    [SerializeField] private TextMeshProUGUI questDescription;

    [Header("Variables from the item ")]
    public Quest thisQuest;
    public QuestManager thisQuestManager;

    public void Setup(Quest newQuest, QuestManager newQuestManager)
    {
        thisQuest = newQuest;
        thisQuestManager = newQuestManager;

        if (thisQuest)
        {
            questTitle.text = thisQuest.title;
            questDescription.text = thisQuest.description;
        }
    }
}
