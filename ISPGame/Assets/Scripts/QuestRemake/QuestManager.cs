using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{

    [Header("Inventory Information")]
    public QuestInventory questInventory;
    [SerializeField] private GameObject blankQuest;
    [SerializeField] private GameObject questPanel;

    void OnEnable()
    {
        ClearQuestSlots();
        MakeQuestSlots();
    }

    void MakeQuestSlots()
    {
        if (questInventory)
        {
            for (int i = 0; i < questInventory.myQuests.Count; i++)
            {
                if (questInventory.myQuests[i].isActive)
                {
                    GameObject temp = Instantiate(blankQuest, questPanel.transform.position, Quaternion.identity);
                    // Gets the local scale of game object
                    Vector3 objectScale = temp.transform.localScale;

                    float screenScale = Screen.width / 2560f;

                    // Sets the local scale of game object
                    temp.transform.localScale = new Vector3(objectScale.x * screenScale, objectScale.y * screenScale, objectScale.z * screenScale);

                    temp.transform.SetParent(questPanel.transform);

                    QuestSlot newSlot = temp.GetComponent<QuestSlot>();
                    if (newSlot)
                    {
                        newSlot.Setup(questInventory.myQuests[i], this);

                    }
                }
            }
        }
    }



    
    void ClearQuestSlots()
    {
        for (int i = 0; i < questPanel.transform.childCount; i++)
        {
            Destroy(questPanel.transform.GetChild(i).gameObject);
        }
    }

    public void resetQuests()
    {
        for (int i = 0; i < questInventory.myQuests.Count; i++)
        {
            questInventory.myQuests[i].questGoal.currentAmount = 0;
            questInventory.myQuests[i].isActive = false;
        }

        questInventory.myQuests.Clear();
    }
}
