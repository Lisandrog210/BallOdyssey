using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToCheckpoint : MonoBehaviour {
    
    GameObject cm;
    CheckpointManager cmClass;  
    GameObject deathPanel;

    private void Awake()
    {
        cm = GameObject.FindGameObjectWithTag("CheckpointManager");       
        cmClass = cm.GetComponent<CheckpointManager>();
        deathPanel = GameObject.FindGameObjectWithTag("DeathPanel");
        deathPanel.gameObject.SetActive(false);
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
