using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButtonScript : MonoBehaviour
{

    public GameObject inventory;
    public bool inventoryIsClosed;

    public GameObject questScreen;
    public bool questScreenActive;
    public float displayTime;
    float timerDisplay;

    // Start is called before the first frame update
    void Start()
    {
        inventoryIsClosed = false;
        questScreenActive = false;
        questScreen.SetActive(false);
        timerDisplay = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryIsClosed)
            {
                inventory.SetActive(true);
                inventoryIsClosed = false;
            }
            else
            {
                inventory.SetActive(false);
                inventoryIsClosed = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && !questScreenActive)
        {
            questScreenActive = true;
            questScreen.SetActive(true);
            timerDisplay = displayTime;
        }

        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                questScreenActive = false;
                questScreen.SetActive(false);
            }
        }
    }
}
