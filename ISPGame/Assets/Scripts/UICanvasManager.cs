using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasManager : MonoBehaviour
{
    public GameObject InventoryPanel;
    bool inventoryPanelState;

    public GameObject NotificationScreen;

    public GameObject QuestScreen;
    bool questScreenIsActive;
    public float displayTime;
    float timerDisplay;

    // Start is called before the first frame update
    void Start()
    {
        InventoryPanel.SetActive(false);
        InventoryPanel.GetComponent<InventoryManager>().resetInventory();
        inventoryPanelState = false;
        QuestScreen.SetActive(false);
        timerDisplay = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                QuestScreen.SetActive(false);
                questScreenIsActive = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && !questScreenIsActive)
        {
            QuestScreen.SetActive(true);
            questScreenIsActive = true;
            timerDisplay = displayTime;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanelState = !inventoryPanelState;
            InventoryPanel.SetActive(inventoryPanelState);
        }
    }
}
