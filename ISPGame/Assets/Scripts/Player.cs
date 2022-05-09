using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	
	void Update()
    {
       float horizontal = Input.GetAxis("Horizontal");
       float vertical = Input.GetAxis("Vertical");
       Vector2 position = transform.position;
       position.x = position.x + 5.0f * horizontal * Time.deltaTime;
       position.y = position.y + 5.0f * vertical * Time.deltaTime;
       transform.position = position;
	   
	   if(Input.GetKeyDown(KeyCode.Space))
	   {
		   inventory.Save();
	   }
	   
	   if(Input.GetKeyDown(KeyCode.Return))
	   {
		   inventory.Load();
	   }
    }
	
	public InventoryObject inventory;
   
	private void OnTriggerEnter2D(Collider2D collision)
    {
        var item = collision.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(collision.gameObject);
        }
    }
	
	private void OnApplicationQuit()
	{
		inventory.Container.Clear();
	}
}
