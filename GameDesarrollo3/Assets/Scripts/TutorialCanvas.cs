using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCanvas : MonoBehaviour
{
    public GameObject tutorialCanvas;
    private void Start()
    {       
        Time.timeScale = 0;
        if (PlayerPrefs.GetInt("WasTutorialDone") == 1)        
            this.Destroy();
        else        
            tutorialCanvas.SetActive(true);
    }

    public void Destroy()
    {        
        PlayerPrefs.SetInt("WasTutorialDone", 1);
        Time.timeScale = 1;
        tutorialCanvas.SetActive(false);
    }
}
