using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseCheck : MonoBehaviour
{
    public bool coinPicked = false;  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WinCheck" && coinPicked == true)
        {
            WinScene();

        }else if (collision.gameObject.tag == "WinCheck" && coinPicked == false)
            {
                GameOverScene();
            }

        if (collision.gameObject.tag == "LoseCheck")
        {
            GameOverScene();
        }

        if (collision.gameObject.tag == "Coin")
        {
            Debug.Log(coinPicked);
            coinPicked = true;
            collision.gameObject.SetActive(false);
        }

    }

    

    public void WinScene()
    {
        SceneManager.LoadScene("WinMenu");
    }

    public void GameOverScene()
    {
        SceneManager.LoadScene("GameOverMenu");
    }
}
