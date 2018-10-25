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
    

    private void Awake()
    {        
        deathPanel = GameObject.FindGameObjectWithTag("DeathPanel");
        cm = GameObject.FindGameObjectWithTag("CheckpointManager");
        lm = GameObject.FindGameObjectWithTag("LifeManager");
        canvas = GameObject.FindGameObjectWithTag("UI");
        uiman = canvas.GetComponent<UIManager>();
        cmClass = cm.GetComponent<CheckpointManager>();
        livesManager = lm.GetComponent<LivesManager>();  
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
            LevelManager.Instance.SetLevelWon(level, StarsManager.Instance.GetStarsTaken(0), StarsManager.Instance.GetStarsTaken(1), StarsManager.Instance.GetStarsTaken(2));
            WinScene();
        }        

        if(collider.tag == "LoseCheck" && lives > 0) {
            RemoveLife();            
            this.gameObject.SetActive(false);
        }
        else if(collider.tag == "LoseCheck" && lives == 0 )
            GameOverScene();
    }
    

    private void RemoveLife()
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
