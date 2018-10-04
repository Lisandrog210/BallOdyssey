using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseCheck : MonoBehaviour {
        
    public int level;


    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "WinCheck" ) {
           LevelSelectManager.instance.IsLevelWon(level);
            WinScene();
        }        

        if(collider.tag == "LoseCheck") {
            GameOverScene();
        }


    }

    public void WinScene() {
        SceneManager.LoadScene("LevelSelect");
    }

    public void GameOverScene() {
        SceneManager.LoadScene("GameOverMenu");
    }
  

}
