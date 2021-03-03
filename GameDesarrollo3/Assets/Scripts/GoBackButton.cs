using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GoBackButton : MonoBehaviour {

    GameObject pausePanel;
    GameObject backPanel;
    [SerializeField] GameObject pauseButton;

    void Awake ()
    {
        pausePanel = GameObject.FindGameObjectWithTag("PausePanel");
        backPanel = GameObject.FindGameObjectWithTag("BackPanel");
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(UnPause);
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            UnPause();
    }

    private void UnPause()
    {        
        GameObject.FindGameObjectWithTag("UI").transform.Find("PauseButton").gameObject.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 1;      
    }
}
