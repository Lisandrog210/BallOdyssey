using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetInt("Lvl1Won", 0) == 1)
            LevelManager.Instance.SetLevelWon(0);
        if (PlayerPrefs.GetInt("Lvl2Won", 0) == 1)
            LevelManager.Instance.SetLevelWon(1);
        if (PlayerPrefs.GetInt("Lvl3Won", 0) == 1)
            LevelManager.Instance.SetLevelWon(2);
        if (PlayerPrefs.GetInt("Lvl4Won", 0) == 1)
            LevelManager.Instance.SetLevelWon(3);
        if (PlayerPrefs.GetInt("Lvl5Won", 0) == 1)
            LevelManager.Instance.SetLevelWon(4);
        if (PlayerPrefs.GetInt("Lvl6Won", 0) == 1)
            LevelManager.Instance.SetLevelWon(5);
        if (PlayerPrefs.GetInt("Lvl7Won", 0) == 1)
            LevelManager.Instance.SetLevelWon(6);
        if (PlayerPrefs.GetInt("Lvl8Won", 0) == 1)
            LevelManager.Instance.SetLevelWon(7);
        if (PlayerPrefs.GetInt("Lvl9Won", 0) == 1)
            LevelManager.Instance.SetLevelWon(8);

        if (PlayerPrefs.GetInt("Star1.1", 0) == 1)
            LevelManager.Instance.SetStarTaken(0, 0);
        if (PlayerPrefs.GetInt("Star1.2", 0) == 1)
            LevelManager.Instance.SetStarTaken(0, 1);
        if (PlayerPrefs.GetInt("Star1.3", 0) == 1)
            LevelManager.Instance.SetStarTaken(0, 2);

        if (PlayerPrefs.GetInt("Star2.1", 0) == 1)
            LevelManager.Instance.SetStarTaken(1, 0);
        if (PlayerPrefs.GetInt("Star2.2", 0) == 1)
            LevelManager.Instance.SetStarTaken(1, 1);
        if (PlayerPrefs.GetInt("Star2.3", 0) == 1)
            LevelManager.Instance.SetStarTaken(1, 2);

        if (PlayerPrefs.GetInt("Star3.1", 0) == 1)
            LevelManager.Instance.SetStarTaken(2, 0);
        if (PlayerPrefs.GetInt("Star3.2", 0) == 1)
            LevelManager.Instance.SetStarTaken(2, 1);
        if (PlayerPrefs.GetInt("Star3.3", 0) == 1)
            LevelManager.Instance.SetStarTaken(2, 2);

        if (PlayerPrefs.GetInt("Star4.1", 0) == 1)
            LevelManager.Instance.SetStarTaken(3, 0);
        if (PlayerPrefs.GetInt("Star4.2", 0) == 1)
            LevelManager.Instance.SetStarTaken(3, 1);
        if (PlayerPrefs.GetInt("Star4.3", 0) == 1)
            LevelManager.Instance.SetStarTaken(3, 2);

        if (PlayerPrefs.GetInt("Star5.1") == 1)
            LevelManager.Instance.SetStarTaken(4, 0);
        if (PlayerPrefs.GetInt("Star5.2", 0) == 1)
            LevelManager.Instance.SetStarTaken(4, 1);
        if (PlayerPrefs.GetInt("Star5.3", 0) == 1)
            LevelManager.Instance.SetStarTaken(4, 2);

        if (PlayerPrefs.GetInt("Star6.1", 0) == 1)
            LevelManager.Instance.SetStarTaken(5, 0);
        if (PlayerPrefs.GetInt("Star6.2", 0) == 1)
            LevelManager.Instance.SetStarTaken(5, 1);
        if (PlayerPrefs.GetInt("Star6.3", 0) == 1)
            LevelManager.Instance.SetStarTaken(5, 2);

        if (PlayerPrefs.GetInt("Star7.1", 0) == 1)
            LevelManager.Instance.SetStarTaken(6, 0);
        if (PlayerPrefs.GetInt("Star7.2", 0) == 1)
            LevelManager.Instance.SetStarTaken(6, 1);
        if (PlayerPrefs.GetInt("Star7.3", 0) == 1)
            LevelManager.Instance.SetStarTaken(6, 2);

        if (PlayerPrefs.GetInt("Star8.1", 0) == 1)
            LevelManager.Instance.SetStarTaken(7, 0);
        if (PlayerPrefs.GetInt("Star8.2", 0) == 1)
            LevelManager.Instance.SetStarTaken(7, 1);
        if (PlayerPrefs.GetInt("Star8.3", 0) == 1)
            LevelManager.Instance.SetStarTaken(7, 2);

        if (PlayerPrefs.GetInt("Star9.1", 0) == 1)
            LevelManager.Instance.SetStarTaken(8, 0);
        if (PlayerPrefs.GetInt("Star9.2", 0) == 1)
            LevelManager.Instance.SetStarTaken(8, 1);
        if (PlayerPrefs.GetInt("Star9.3", 0) == 1)
            LevelManager.Instance.SetStarTaken(8, 2);
    }
  
}
