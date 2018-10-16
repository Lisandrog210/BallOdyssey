using UnityEngine;

public class LevelManager
{
    private Level[] levels;
    private const int levelQtty = 4;

    private static LevelManager instance;

    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LevelManager();
            }
            return instance;
        }
    }


    private LevelManager()
    {
        levels = new Level[levelQtty];

        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].won = false;
            levels[i].stars = new bool[3] {false, false, false};
        }
    }


    public int GetLevelQuantity()
    {
        return levelQtty;
    }

    public void SetLevelWon(int level, bool star1, bool star2, bool star3)
    {
        // agregar chequeo de bounds array

        levels[level].won = true;
        levels[level].stars[0] = star1;
        levels[level].stars[1] = star2;
        levels[level].stars[2] = star3;
    }
       
    public bool ReturnStars(int aux,int aux2)
    {
        return levels[aux].stars[aux2];
    }

    public Level GetLevel(int level)
    {
        if (level >= levels.Length)
        {

        }

        return levels[level];

/*        if (_level == 1)      
            lvl1Won = true;
        if (_level == 2)
            lvl2Won = true;
        if (_level == 3)
            lvl3Won = true;
        if (_level == 4)
            lvl4Won = true;*/
    }

    /*public void SetStars(int lvl, bool star1, bool star2, bool star3)
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
    }*/
       

    /*public bool ReturnLevel1Won()
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
    }*/
}
