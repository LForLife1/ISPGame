using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject canvasObj;
    // Start is called before the first frame update
    void Start()
    {
        canvasObj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        canvasObj.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitToDesktop()
    {
        canvasObj.SetActive(false);
        Application.Quit();
    }
}
