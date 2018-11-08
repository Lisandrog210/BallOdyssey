using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoBackButton : MonoBehaviour {

    GameObject pausePanel;

	void Awake ()
    {
        pausePanel = GameObject.FindGameObjectWithTag("PausePanel");
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(UnPause);
    }

    private void UnPause()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
