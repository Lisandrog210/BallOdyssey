using UnityEngine;

public class LevelManager
{
    private Level[] levels;
    private const int levelQtty = 10;
    private int starCounter;
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
            levels[i].won = true;
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
        if (star1)
            starCounter++;
        if (star2)
            starCounter++;
        if (star3)
            starCounter++;
        for (int i = 0; i < starCounter; i++)
        {
            levels[level].stars[i] = true;
            
        }
        starCounter = 0;

        /*levels[level].stars[0] = star1;
        levels[level].stars[1] = star2;
        levels[level].stars[2] = star3;*/
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
        //Debug.Log("error get level" + level);
        return levels[level];
    }  

    public void SetLevelWon(int _levelNumber)
    {
        levels[_levelNumber].won = true;
    }

    public void SetLevelNotWon(int _levelNumber)
    {
        levels[_levelNumber].won = false;
    }

    public void SetStarTaken(int _lvlNumber, int _starNumber)
    {
        levels[_lvlNumber].stars[_starNumber] = true;
    }
    public void SetStarNotTaken(int _lvlNumber, int _starNumber)
    {
        levels[_lvlNumber].stars[_starNumber] = false;
    }
}
