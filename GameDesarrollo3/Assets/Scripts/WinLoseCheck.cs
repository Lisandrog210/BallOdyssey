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
    GameObject deathPanel2;
    GameObject ComingSoonPanel;
    GameObject MoreLivesPanel;
    GameObject YouWinPanel;

    [SerializeField] AudioClip starSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip loseSound;

    AudioSource audioS;

    private void Awake()
    {
        MoreLivesPanel = GameObject.FindGameObjectWithTag("MoreLivesPanel");
        ComingSoonPanel = GameObject.FindGameObjectWithTag("ComingSoonPanel");
        deathPanel = GameObject.FindGameObjectWithTag("DeathPanel");
        deathPanel2 = GameObject.FindGameObjectWithTag("DeathPanel2");
        YouWinPanel = GameObject.FindGameObjectWithTag("YouWinPanel");
        cm = GameObject.FindGameObjectWithTag("CheckpointManager");
        lm = GameObject.FindGameObjectWithTag("LifeManager");
        canvas = GameObject.FindGameObjectWithTag("UI");
        uiman = canvas.GetComponent<UIManager>();
        cmClass = cm.GetComponent<CheckpointManager>();
        livesManager = lm.GetComponent<LivesManager>();
        audioS = GetComponent<AudioSource>();


        if (ComingSoonPanel && ComingSoonPanel.activeSelf)
            ComingSoonPanel.SetActive(false);
        if (MoreLivesPanel.activeSelf)
            MoreLivesPanel.SetActive(false);
        if (YouWinPanel.activeSelf)
            YouWinPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Coin")
        {
            audioS.PlayOneShot(starSound, 1f);
            StarsManager.Instance.SetStarsTaken(collider.gameObject);
            StarsManager.Instance.AddStarsToResetList(collider.gameObject);
            collider.gameObject.SetActive(false);
        }

        if (collider.tag == "WinCheck" )
        {
            audioS.PlayOneShot(winSound, 1f);

            if (level == 8)            
                ComingSoonPanel.SetActive(true);

            Time.timeScale = 0;
            LevelManager.Instance.SetLevelWon(level, StarsManager.Instance.GetStarsTaken(0), StarsManager.Instance.GetStarsTaken(1), StarsManager.Instance.GetStarsTaken(2));
            YouWinPanel.SetActive(true);
            
            //WinScene();
        }

        if (collider.tag == "LoseCheck" && lives > 0)
        {
            //RemoveLife();
            //Time.timeScale = 0;
            audioS.PlayOneShot(loseSound, 1f);
            this.gameObject.SetActive(false);
        }
        else if (collider.tag == "LoseCheck" && lives == 0 && Time.timeScale == 1)
        {
            Debug.Log("ACTIVATE MORELIVES");
            audioS.PlayOneShot(loseSound, 1f);
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
