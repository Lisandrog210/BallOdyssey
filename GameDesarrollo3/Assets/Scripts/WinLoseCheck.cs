using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseCheck : MonoBehaviour {
        
    public int level;    
   
    GameObject cm;
    CheckpointManager cmClass;
    GameObject[] fallingPlat;
    PlatformFall[] pfClass;   
    
    GameObject canvas;    
    GameObject deathPanel;
    GameObject deathPanel2;
    GameObject ComingSoonPanel;
   
    GameObject YouWinPanel;

    [SerializeField] AudioClip starSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip loseSound;

    AudioSource audioS;

    private void Awake()
    {
       
        ComingSoonPanel = GameObject.FindGameObjectWithTag("ComingSoonPanel");
        //deathPanel = GameObject.FindGameObjectWithTag("DeathPanel");
        //deathPanel2 = GameObject.FindGameObjectWithTag("DeathPanel2");
        YouWinPanel = GameObject.FindGameObjectWithTag("YouWinPanel");
        cm = GameObject.FindGameObjectWithTag("CheckpointManager");      
        canvas = GameObject.FindGameObjectWithTag("UI");       
        cmClass = cm.GetComponent<CheckpointManager>();       
        audioS = GetComponent<AudioSource>();


        if (ComingSoonPanel && ComingSoonPanel.activeSelf)
            ComingSoonPanel.SetActive(false);       
        if (YouWinPanel && YouWinPanel.activeSelf)
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

           /* if (level == 8)            
                ComingSoonPanel.SetActive(true);*/

            Time.timeScale = 0;
            LevelManager.Instance.SetLevelWon(level, StarsManager.Instance.GetStarsTaken(0), StarsManager.Instance.GetStarsTaken(1), StarsManager.Instance.GetStarsTaken(2));
            YouWinPanel.SetActive(true);
            
            //WinScene();
        }

        if (collider.tag == "LoseCheck")
        {            
            //Time.timeScale = 0;
            audioS.PlayOneShot(loseSound, 1f);
            //this.gameObject.SetActive(false);
        }
       
        //GameOverScene();
    } 

    public void WinScene() {
        SceneManager.LoadScene("LevelSelect");
    }

    public void GameOverScene() {
        SceneManager.LoadScene("GameOverMenu");
    }

    private void Update()
    {
          
    }
}
