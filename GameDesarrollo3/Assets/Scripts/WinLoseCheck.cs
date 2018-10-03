using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseCheck : MonoBehaviour {
    public int grabbedCoins = 0;
    [SerializeField] int toCollect;
    public int level;


    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "WinCheck" && grabbedCoins==toCollect) {
           LevelSelectManager.instance.IsLevelWon(level);
            WinScene();
        }
        else if(collider.tag == "WinCheck" && grabbedCoins < toCollect) {
            GameOverScene();
        }

        if(collider.tag == "LoseCheck") {
            GameOverScene();
        }


    }

    public void CheckCoin() {
        grabbedCoins++;        
    }

    void OnEnable() {
        Coin.OnPickedUp += CheckCoin;
    }


    void OnDisable() {
        Coin.OnPickedUp -= CheckCoin;
    }



    public void WinScene() {
        SceneManager.LoadScene("LevelSelect");
    }

    public void GameOverScene() {
        SceneManager.LoadScene("GameOverMenu");
    }
  

}
