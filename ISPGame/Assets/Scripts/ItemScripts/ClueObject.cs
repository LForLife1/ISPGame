using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	[CreateAssetMenu(fileName = "New Clue Object", menuName = "Inventory System/Items/Clue")]

public class ClueObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Clue;
    }
}
