using UnityEngine;

public class LevelManager
{
    private Level[] levels;
    private const int levelQtty = 8;

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
        Debug.Log("error get level" + level);
        return levels[level];
    }  
}
