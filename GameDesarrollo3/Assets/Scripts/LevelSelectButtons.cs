using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButtons : MonoBehaviour
{
    [SerializeField] GameObject lvl1GO;
    Button lvl1Button;
    [SerializeField] GameObject lvl2GO;
    Button lvl2Button;
    [SerializeField] GameObject lvl3GO;
    Button lvl3Button;
    [SerializeField] GameObject lvl4GO;
    Button lvl4Button;
    public GameObject lvl3star1;
    public GameObject lvl3star2;
    public GameObject lvl3star3;
    public bool level1Won;
    public bool level2Won;
    public bool level3Won;
    public bool level4Won;
    bool[,] stars;
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

        lvl1Button = lvl1GO.GetComponent<Button>();
        lvl2Button = lvl2GO.GetComponent<Button>();
        lvl3Button = lvl3GO.GetComponent<Button>();
        lvl4Button = lvl4GO.GetComponent<Button>();
        lvl1Button.interactable = true;
        if (instance == null)      
            instance = this;
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    void Update()
    {
        level1Won = LevelSelectManager.instance.ReturnLevel1Won();
        level2Won = LevelSelectManager.instance.ReturnLevel2Won();
        level3Won = LevelSelectManager.instance.ReturnLevel3Won();
        level4Won = LevelSelectManager.instance.ReturnLevel4Won();
        
        if (level1Won == true)        
            lvl2Button.interactable = true;
        if (level2Won == true)
            lvl3Button.interactable = true;
        if (level3Won == true)
            lvl4Button.interactable = true;

        stars = LevelSelectManager.instance.ReturnStars();
        if (stars[2, 0] == true)       
            lvl3star1.gameObject.SetActive(true);
        if (stars[2, 1] == true)
            lvl3star2.gameObject.SetActive(true);
        if (stars[2, 2] == true)
            lvl3star3.gameObject.SetActive(true);

        Debug.Log(stars[2, 0]);


    }
}
