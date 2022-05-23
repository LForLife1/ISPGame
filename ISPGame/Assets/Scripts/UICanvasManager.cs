using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasManager : MonoBehaviour
{
    public GameObject InventoryPanel;
    public GameObject NotificationScreen;

    public GameObject QuestScreen;
    bool questScreenIsActive;
    public float displayTime;
    float timerDisplay;

    // Start is called before the first frame update
    void Start()
    {
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

        if (Input.GetKey(KeyCode.Q) && !questScreenIsActive)
        {
            QuestScreen.SetActive(true);
            questScreenIsActive = true;
            timerDisplay = displayTime;
        }
    }
}
