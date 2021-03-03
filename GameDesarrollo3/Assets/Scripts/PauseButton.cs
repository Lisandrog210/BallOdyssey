using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    GameObject pausePanel;
    GameObject pauseButton;    

    private void Awake()
    {
        pausePanel = GameObject.FindGameObjectWithTag("PausePanel");
        pauseButton = GameObject.FindGameObjectWithTag("PauseButton");
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(OpenPausePanel);
        if(pausePanel)
            pausePanel.SetActive(false);
    }    
    
    public void OpenPausePanel()
    {
        if(pauseButton)
            pauseButton.SetActive(false);
        pausePanel.SetActive(true);        
        Time.timeScale = 0;
    }
}
