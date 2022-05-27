using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New QuestList", menuName = "Quest/QuestList")]
public class QuestInventory : ScriptableObject
{
    public List<Quest> myQuests = new List<Quest>();
}