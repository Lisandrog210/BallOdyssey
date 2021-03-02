using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    
    private void OnApplicationQuit()
    {
        if (LevelManager.Instance.GetLevel(0).won)
            PlayerPrefs.SetInt("Lvl1Won", 1);
        if (LevelManager.Instance.GetLevel(1).won)
            PlayerPrefs.SetInt("Lvl2Won", 1);
        if (LevelManager.Instance.GetLevel(2).won)
            PlayerPrefs.SetInt("Lvl3Won", 1);
        if (LevelManager.Instance.GetLevel(3).won)
            PlayerPrefs.SetInt("Lvl4Won", 1);
        if (LevelManager.Instance.GetLevel(4).won)
            PlayerPrefs.SetInt("Lvl5Won", 1);
        if (LevelManager.Instance.GetLevel(5).won)
            PlayerPrefs.SetInt("Lvl6Won", 1);
        if (LevelManager.Instance.GetLevel(6).won)
            PlayerPrefs.SetInt("Lvl7Won", 1);
        if (LevelManager.Instance.GetLevel(7).won)
            PlayerPrefs.SetInt("Lvl8Won", 1);
        if (LevelManager.Instance.GetLevel(8).won)
            PlayerPrefs.SetInt("Lvl9Won", 1);

        if (LevelManager.Instance.GetLevel(0).stars[0])
            PlayerPrefs.SetInt("Star1.1", 1);
        if (LevelManager.Instance.GetLevel(0).stars[1])
            PlayerPrefs.SetInt("Star1.2", 1);
        if (LevelManager.Instance.GetLevel(0).stars[2])
            PlayerPrefs.SetInt("Star1.3", 1);

        if (LevelManager.Instance.GetLevel(1).stars[0])
            PlayerPrefs.SetInt("Star2.1", 1);
        if (LevelManager.Instance.GetLevel(1).stars[1])
            PlayerPrefs.SetInt("Star2.2", 1);
        if (LevelManager.Instance.GetLevel(1).stars[2])
            PlayerPrefs.SetInt("Star2.3", 1);

        if (LevelManager.Instance.GetLevel(2).stars[0])
            PlayerPrefs.SetInt("Star3.1", 1);
        if (LevelManager.Instance.GetLevel(2).stars[1])
            PlayerPrefs.SetInt("Star3.2", 1);
        if (LevelManager.Instance.GetLevel(2).stars[2])
            PlayerPrefs.SetInt("Star3.3", 1);

        if (LevelManager.Instance.GetLevel(3).stars[0])
            PlayerPrefs.SetInt("Star4.1", 1);
        if (LevelManager.Instance.GetLevel(3).stars[1])
            PlayerPrefs.SetInt("Star4.2", 1);
        if (LevelManager.Instance.GetLevel(3).stars[2])
            PlayerPrefs.SetInt("Star4.3", 1);

        if (LevelManager.Instance.GetLevel(4).stars[0])
            PlayerPrefs.SetInt("Star5.1", 1);
        if (LevelManager.Instance.GetLevel(4).stars[1])
            PlayerPrefs.SetInt("Star5.2", 1);
        if (LevelManager.Instance.GetLevel(4).stars[2])
            PlayerPrefs.SetInt("Star5.3", 1);

        if (LevelManager.Instance.GetLevel(5).stars[0])
            PlayerPrefs.SetInt("Star6.1", 1);
        if (LevelManager.Instance.GetLevel(5).stars[1])
            PlayerPrefs.SetInt("Star6.2", 1);
        if (LevelManager.Instance.GetLevel(5).stars[2])
            PlayerPrefs.SetInt("Star6.3", 1);

        if (LevelManager.Instance.GetLevel(6).stars[0])
            PlayerPrefs.SetInt("Star7.1", 1);
        if (LevelManager.Instance.GetLevel(6).stars[1])
            PlayerPrefs.SetInt("Star7.2", 1);
        if (LevelManager.Instance.GetLevel(6).stars[2])
            PlayerPrefs.SetInt("Star7.3", 1);

        if (LevelManager.Instance.GetLevel(7).stars[0])
            PlayerPrefs.SetInt("Star8.1", 1);
        if (LevelManager.Instance.GetLevel(7).stars[1])
            PlayerPrefs.SetInt("Star8.2", 1);
        if (LevelManager.Instance.GetLevel(7).stars[2])
            PlayerPrefs.SetInt("Star8.3", 1);

        if (LevelManager.Instance.GetLevel(8).stars[0])
            PlayerPrefs.SetInt("Star9.1", 1);
        if (LevelManager.Instance.GetLevel(8).stars[1])
            PlayerPrefs.SetInt("Star9.2", 1);
        if (LevelManager.Instance.GetLevel(8).stars[2])
            PlayerPrefs.SetInt("Star9.3", 1);
    }
}
