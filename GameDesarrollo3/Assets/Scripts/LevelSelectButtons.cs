using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButtons : MonoBehaviour
{
    [SerializeField] Button[] lvlButtons;
    [SerializeField] Image[] coinImage;
    [SerializeField] GameObject[] worlds;
 

    public bool level1Won;
    public bool level2Won;
    public bool level3Won;
    public bool level4Won;
    public static LevelSelectButtons instance;

    public static LevelSelectButtons Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<LevelSelectButtons>();
            return instance;
        }
    }

    

    private void Awake()
    {
        lvlButtons[0].interactable = true;
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    void Start()
    {
        for (int i = 1; i <= LevelManager.Instance.GetLevelQuantity(); i++)
        {
            Level level = LevelManager.Instance.GetLevel(i - 1);
            lvlButtons[i].interactable = level.won;
            if (level.stars[0])
                coinImage[(i - 3) + (2 * i)].enabled = true;
            if (level.stars[1])
                coinImage[(i - 2) + (2 * i)].enabled = true;
            if (level.stars[2])
                coinImage[(i - 1) + (2 * i)].enabled = true;
        }
    }
}
