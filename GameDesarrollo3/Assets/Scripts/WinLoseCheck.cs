using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ExaGames.Common.TimeBasedLifeSystem;

public class WinLoseCheck : MonoBehaviour {
        
    public int level;    
    public int lives;
    GameObject cm;
    CheckpointManager cmClass;
    GameObject[] fallingPlat;
    PlatformFall[] pfClass;
    LivesManager livesManager;
    GameObject lm;
    GameObject canvas;
    UIManager uiman;
    GameObject deathPanel;
    GameObject ComingSoonPanel;
    GameObject MoreLivesPanel;    

    private void Awake()
    {
        MoreLivesPanel = GameObject.FindGameObjectWithTag("MoreLivesPanel");
        ComingSoonPanel = GameObject.FindGameObjectWithTag("ComingSoonPanel");
        deathPanel = GameObject.FindGameObjectWithTag("DeathPanel");
        cm = GameObject.FindGameObjectWithTag("CheckpointManager");
        lm = GameObject.FindGameObjectWithTag("LifeManager");
        canvas = GameObject.FindGameObjectWithTag("UI");
        uiman = canvas.GetComponent<UIManager>();
        cmClass = cm.GetComponent<CheckpointManager>();
        livesManager = lm.GetComponent<LivesManager>();

        if (ComingSoonPanel.activeSelf)
            ComingSoonPanel.SetActive(false);
        if (MoreLivesPanel.activeSelf)
            MoreLivesPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Coin")
        {
            StarsManager.Instance.SetStarsTaken(collider.gameObject);
            StarsManager.Instance.AddStarsToResetList(collider.gameObject);
            collider.gameObject.SetActive(false);
        }

        if (collider.tag == "WinCheck" )
        {
            if (level == 8)            
                ComingSoonPanel.SetActive(true);

            Time.timeScale = 0;
            LevelManager.Instance.SetLevelWon(level, StarsManager.Instance.GetStarsTaken(0), StarsManager.Instance.GetStarsTaken(1), StarsManager.Instance.GetStarsTaken(2));
            
            WinScene();
        }

        if (collider.tag == "LoseCheck" && lives > 0)
        {
            //RemoveLife();
            //Time.timeScale = 0;
            this.gameObject.SetActive(false);
        }
        else if (collider.tag == "LoseCheck" && lives == 0)
        {
            Debug.Log("ACTIVATE MORELIVES");
            MoreLivesPanel.SetActive(true);
            this.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        //GameOverScene();
    }
    

    public void RemoveLife()
    {        
        lives--;
        canvas.GetComponent<UIManager>().ConsumeLife();
    }

    public void WinScene() {
        SceneManager.LoadScene("LevelSelect");
    }

    public void GameOverScene() {
        SceneManager.LoadScene("GameOverMenu");
    }

    private void Update()
    {
        lives = livesManager.Lives;       
    }
}
