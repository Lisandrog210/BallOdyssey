using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ExaGames.Common.TimeBasedLifeSystem;

public class MoveToCheckpoint : MonoBehaviour
{

    GameObject cm;
    CheckpointManager cmClass;
    public GameObject deathPanel;
    public GameObject deathPanel2;
    PlatformFall[] pfClass;
    GameObject[] fallingPlat;
    PlatformMove[] pmClass;
    GameObject[] movingPlatform;
    GameObject player;
    WinLoseCheck wlc;
    LivesManager livesManager;
    GameObject lm;

    private void Awake()
    {
        lm = GameObject.FindGameObjectWithTag("LifeManager");
        livesManager = lm.GetComponent<LivesManager>();
        cm = GameObject.FindGameObjectWithTag("CheckpointManager");
        cmClass = cm.GetComponent<CheckpointManager>();
        deathPanel = GameObject.FindGameObjectWithTag("DeathPanel");
        deathPanel2 = GameObject.FindGameObjectWithTag("DeathPanel2");
        fallingPlat = GameObject.FindGameObjectsWithTag("FallingPlatform");
        movingPlatform = GameObject.FindGameObjectsWithTag("MovingPlatform");
        pfClass = new PlatformFall[fallingPlat.Length];
        pmClass = new PlatformMove[movingPlatform.Length];

        if (deathPanel)
            deathPanel.gameObject.SetActive(false);
        if(deathPanel2)
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
        Debug.Log("CHOQUE");
        if (collider.tag == "LoseCheck" && livesManager.Lives > 0)
        {
            Debug.Log("CHOQUE2");

            wlc.RemoveLife();

            if (cmClass.lastActivated)
            {
                Debug.Log("OPEN DEATH PANEL");
                cmClass.ResetCoins();
                deathPanel.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Debug.Log("OPEN DEATH PANEL 2");
                deathPanel2.gameObject.SetActive(true);
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



}
