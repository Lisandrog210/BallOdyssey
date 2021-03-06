﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToCheckpoint : MonoBehaviour
{

    GameObject cm;
    CheckpointManager cmClass;
    public GameObject deathPanel;
    public GameObject deathPanel2;
    public GameObject buttonPause;
    PlatformFall[] pfClass;
    GameObject[] fallingPlat;
    PlatformMove[] pmClass;
    GameObject[] movingPlatform;
    GameObject player;
    WinLoseCheck wlc;    

    private void Awake()
    {
       
        cm = GameObject.FindGameObjectWithTag("CheckpointManager");
        cmClass = cm.GetComponent<CheckpointManager>();
        deathPanel = GameObject.FindGameObjectWithTag("DeathPanel");
        deathPanel2 = GameObject.FindGameObjectWithTag("DeathPanel2");
        fallingPlat = GameObject.FindGameObjectsWithTag("FallingPlatform");
        movingPlatform = GameObject.FindGameObjectsWithTag("MovingPlatform");
        buttonPause = GameObject.FindGameObjectWithTag("PauseButton");
        pfClass = new PlatformFall[fallingPlat.Length];
        pmClass = new PlatformMove[movingPlatform.Length];

        if (deathPanel && deathPanel.activeSelf)      
            deathPanel.gameObject.SetActive(false);
        
        if (deathPanel2 && deathPanel2.activeSelf)       
            deathPanel2.gameObject.SetActive(false);
        

        wlc = GameObject.FindGameObjectWithTag("Ball").GetComponent<WinLoseCheck>();
        this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        for (int i = 0; i < fallingPlat.Length; i++)
        {
            pfClass[i] = fallingPlat[i].GetComponent<PlatformFall>();
        }

        for (int i = 0; i < movingPlatform.Length; i++)
        {
            pmClass[i] = movingPlatform[i].GetComponent<PlatformMove>();
        }

        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "LoseCheck")
        {            

            if (cmClass.lastActivated)
            {               
                cmClass.ResetCoins();               
                deathPanel.gameObject.SetActive(true);
                buttonPause.SetActive(false);
                Time.timeScale = 0;
            }
            else
            {                
                deathPanel2.gameObject.SetActive(true);
                buttonPause.SetActive(false);
                Time.timeScale = 0;
            }
        }

    }

    public void Move()
    {
        if (cmClass.lastActivated)
        {
            for (int i = 0; i < pfClass.Length; i++)
            {
                pfClass[i].ResetPosition();
            }

            for (int i = 0; i < pmClass.Length; i++)
            {
                pmClass[i].ResetPosition();
            }
            deathPanel.gameObject.SetActive(false);
            Time.timeScale = 1;            
            this.gameObject.SetActive(true);
            this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            this.transform.position = cmClass.lastActivated.transform.position;
        }
        else
        {
            deathPanel2.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void GameOverScene()
    {
        SceneManager.LoadScene("GameOverMenu");
    }

    private void Update()
    {
    }


}
