using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButtons : MonoBehaviour
{
    [SerializeField] Button[] lvlButtons;
    [SerializeField] Image[] coinImage;

    public GameObject lvl3star1;
    public GameObject lvl3star2;
    public GameObject lvl3star3;
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
            {
                instance = FindObjectOfType<LevelSelectButtons>();
            }
            return instance;
        }
    }


    private void Awake()
    {
        if (lvlButtons.Length >= 1)
        { 
            lvlButtons[0].interactable = true;
        }

        if (instance == null)      
            instance = this;
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    void Start()
    {
        for (int i = 1; i < LevelManager.Instance.GetLevelQuantity(); i++)
        {
            Level level = LevelManager.Instance.GetLevel(i - 1);

            lvlButtons[i].interactable = level.won;
            if (level.stars[0])
                coinImage[1 * i + 1].enabled = true;
            if (level.stars[1])
                coinImage[1 * i + 2].enabled = true;
            if (level.stars[2])
                coinImage[1 * i + 3].enabled = true;
        }
    }


    void Update()
    {
        /*level1Won = LevelManager.instance.ReturnLevel1Won();
        level2Won = LevelManager.instance.ReturnLevel2Won();
        level3Won = LevelManager.instance.ReturnLevel3Won();
        level4Won = LevelManager.instance.ReturnLevel4Won();
        
        if (level1Won == true)        
            lvl2Button.interactable = true;
        if (level2Won == true)
            lvl3Button.interactable = true;
        if (level3Won == true)
            lvl4Button.interactable = true;
            
        stars = LevelManager.instance.ReturnStars();
        if (stars[2, 0] == true)       
            lvl3star1.gameObject.SetActive(true);
        if (stars[2, 1] == true)
            lvl3star2.gameObject.SetActive(true);
        if (stars[2, 2] == true)
            lvl3star3.gameObject.SetActive(true);

        Debug.Log(stars[2, 0]);
        */

    }
}
