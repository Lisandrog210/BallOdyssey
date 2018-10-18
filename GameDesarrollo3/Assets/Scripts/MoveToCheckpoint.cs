using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToCheckpoint : MonoBehaviour {
    
    GameObject cm;
    CheckpointManager cmClass;  
    GameObject deathPanel;
    PlatformFall[] pfClass;
    GameObject[] fallingPlat;

    private void Awake()
    {
        cm = GameObject.FindGameObjectWithTag("CheckpointManager");       
        cmClass = cm.GetComponent<CheckpointManager>();
        deathPanel = GameObject.FindGameObjectWithTag("DeathPanel");
        fallingPlat = GameObject.FindGameObjectsWithTag("FallingPlatform");
        pfClass = new PlatformFall[fallingPlat.Length];
        deathPanel.gameObject.SetActive(false);

        for (int i = 0; i < fallingPlat.Length; i++)
        {
            pfClass[i] = fallingPlat[i].GetComponent<PlatformFall>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "LoseCheck")
        {
            if (cmClass.lastActivated)
            {
                deathPanel.gameObject.SetActive(true);
            }
            else
                GameOverScene();
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

            deathPanel.gameObject.SetActive(false);
            this.gameObject.SetActive(true);
            this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            this.transform.position = cmClass.lastActivated.transform.position;
        }
        else
            GameOverScene();
    }    
    
    public void GameOverScene()
    {
        SceneManager.LoadScene("GameOverMenu");
    }

    

}
