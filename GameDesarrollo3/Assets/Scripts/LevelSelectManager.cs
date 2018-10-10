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
    bool[,] stars = new bool[3, 3] { { false, false, false }, { false, false, false }, { false, false, false } };

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

    public void Update()
    {
        Debug.Log("LSM"+stars[2, 0]);
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

    public void SetStars(int lvl, bool star1, bool star2, bool star3)
    {
        if (lvl == 1)
        {
            stars[0, 0] = star1;
            stars[0, 1] = star2;
            stars[0, 2] = star3;
        }
        if (lvl == 2)
        {
            stars[1, 0] = star1;
            stars[1, 1] = star2;
            stars[1, 2] = star3;
        }
        if (lvl == 3)
        {
            stars[2, 0] = star1;
            stars[2, 1] = star2;
            stars[2, 2] = star3;
        }
        if (lvl == 4)
        {
            stars[3, 0] = star1;
            stars[3, 1] = star2;
            stars[3, 2] = star3;
        }
    }

    public bool[,] ReturnStars()
    {
        return stars;
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
