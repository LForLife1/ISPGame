using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu][System.Serializable]
public class Quest : ScriptableObject
{
    public bool isActive;

    public string title;
    public string description;

    public QuestGoal questGoal;

    public void Complete()
    {
        isActive = false;
    }
}