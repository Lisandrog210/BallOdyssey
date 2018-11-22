using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    GameObject pausePanel;

    
    private void Awake()
    {
        pausePanel = GameObject.FindGameObjectWithTag("PausePanel");        
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(OpenPausePanel);
    }

    private void Start()
    {
        pausePanel.SetActive(false);
    }
    

    private void OpenPausePanel()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
