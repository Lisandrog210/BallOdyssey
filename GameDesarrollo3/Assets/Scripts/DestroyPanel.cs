using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPanel : MonoBehaviour {

    GameObject pauseButton;
    
    private void Start()
    {
        pauseButton = GameObject.Find("PauseButton");
        if (pauseButton)        
            pauseButton.SetActive(false);
        
        
        Time.timeScale = 0;
    }

    public void Destroy()
    {
        pauseButton.SetActive(true);
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

}
