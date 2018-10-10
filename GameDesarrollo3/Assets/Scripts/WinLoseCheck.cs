using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseCheck : MonoBehaviour {
        
    public int level;
    [SerializeField] public int lives = 3;
    GameObject cm;
    CheckpointManager cmClass;

    private void Start()
    {
        cm = GameObject.FindGameObjectWithTag("CheckpointManager");
        cmClass = cm.GetComponent<CheckpointManager>();
    }

    private void OnTriggerEnter2D(Collider2D collider) {

        if (collider.tag == "WinCheck" )
        {            
           //LevelSelectManager.instance.IsLevelWon(level);
           WinScene();
        }        

        if(collider.tag == "LoseCheck" && lives > 0) {
            //CARGAR PANEL DE VOLVER AL CHECKPOINT
            RemoveLife();
            MoveToCheckpoint();
        }
        else if(collider.tag == "LoseCheck" && lives == 0 )
            GameOverScene();
    }

    private void MoveToCheckpoint()
    {
        if (cmClass.lastActivated)
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            this.transform.position = cmClass.lastActivated.transform.position;
        }else
            GameOverScene();

    }

    private void RemoveLife()
    {
        Debug.Log("LIFE --");
        lives--;
    }

    public void WinScene() {
        SceneManager.LoadScene("LevelSelect");
    }

    public void GameOverScene() {
        SceneManager.LoadScene("GameOverMenu");
    }

    private void Update()
    {
        Debug.Log("LIVES: " + lives);
    }


}
