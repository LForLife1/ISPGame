using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
	
	public InventoryObject inventory;
	
	public int X_SPACE_BETWEEN_ITEM;
	public int NUMBER_OF_COLUMNS;
	public int Y_SPACE_BETWEEN_ITEM;
	public int X_START;
	public int Y_START;
	
	Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        createDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        updateDisplay();

    }
	
	public void createDisplay()
	{
		for(int i = 0; i < inventory.Container.Count; i++)
		{
			var obj = Instantiate(inventory.Container[i].item.prefab, Vector2.zero, Quaternion.identity, transform);
			obj.GetComponent<RectTransform>().localPosition = getPosition(i);
			obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
			
			itemsDisplayed.Add(inventory.Container[i], obj);
		}
	}
	
	public void updateDisplay()
	{
		for(int i = 0; i < inventory.Container.Count; i++)
		{
			if(itemsDisplayed.ContainsKey(inventory.Container[i]))
			{
				itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
			}
			else
			{
				var obj = Instantiate(inventory.Container[i].item.prefab, Vector2.zero, Quaternion.identity, transform);
				obj.GetComponent<RectTransform>().localPosition = getPosition(i);
				obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
				itemsDisplayed.Add(inventory.Container[i], obj);
			}
		}
	}
	
	public Vector2 getPosition(int slot)
	{
		return new Vector2(X_START + (X_SPACE_BETWEEN_ITEM * (slot % NUMBER_OF_COLUMNS)), Y_START + ((-Y_SPACE_BETWEEN_ITEM * (slot / NUMBER_OF_COLUMNS))));
	}		
}
