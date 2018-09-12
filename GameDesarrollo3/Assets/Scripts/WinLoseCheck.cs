using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinLoseCheck : MonoBehaviour
{
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WinCheck")
        {
            WinScene();
            
        }

        if (collision.gameObject.tag == "LoseCheck")
        {
            GameOverScene();
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
