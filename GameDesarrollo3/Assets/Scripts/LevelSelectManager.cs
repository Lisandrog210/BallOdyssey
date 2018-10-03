using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
   
    public bool lvl1Won = false;
    public bool lvl2Won = false;
    public bool lvl3Won = false;
    public bool lvl4Won = false;

    public static LevelSelectManager instance;

    public static LevelSelectManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelSelectManager>();
            }
            return instance;
        }
    }


    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;            
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

    }
   
    public void IsLevelWon(int _level)
    {        
        if (_level == 1)      
            lvl1Won = true;
        if (_level == 2)
            lvl2Won = true;
        if (_level == 3)
            lvl3Won = true;
        if (_level == 4)
            lvl4Won = true;
    }

    public bool ReturnLevel1Won()
    {
        return lvl1Won;
    }
    public bool ReturnLevel2Won()
    {
        return lvl2Won;
    }
    public bool ReturnLevel3Won()
    {
        return lvl3Won;
    }
    public bool ReturnLevel4Won()
    {
        return lvl4Won;
    }
}
