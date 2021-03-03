using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButtons : MonoBehaviour
{
    [SerializeField] Button[] lvlButtons;
    [SerializeField] Image[] coinImage;
    [SerializeField] GameObject[] worlds;
    [SerializeField] public GameObject[] worldLevelButtons;
    [SerializeField] public GameObject[] worldBackgrounds;
    [SerializeField] public GameObject[] worldPosition;
    [SerializeField] public GameObject[] worldButtons;
    [SerializeField] public Sprite[] worldButtonsSprites;
    private bool jungleCentered;
    private bool fireCentered;
    private bool iceCentered;
    private Image jungleImage;
    private Image iceImage;
    private Image fireImage;

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
        if (PlayerPrefs.GetInt("HasBeenReseted", 0) == 1)
        {
            ResetPrefs();
            PlayerPrefs.SetInt("HasBeenReseted", 0);
        }
        /* lvlButtons[0].interactable = true;
         lvlButtons[3].interactable = true;
         lvlButtons[6].interactable = true;*/



        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        jungleImage = worldButtons[0].GetComponent<Image>();
        fireImage = worldButtons[1].GetComponent<Image>();
        iceImage = worldButtons[2].GetComponent<Image>();




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

    void Start()
    {

        for (int i = 1; i < LevelManager.Instance.GetLevelQuantity(); i++)
        {
            Level level = LevelManager.Instance.GetLevel(i - 1);
            lvlButtons[i-1].interactable = level.won;
            if (level.stars[0])
                coinImage[(i - 3) + (2 * i)].enabled = true;
            if (level.stars[1])
                coinImage[(i - 2) + (2 * i)].enabled = true;
            if (level.stars[2])
                coinImage[(i - 1) + (2 * i)].enabled = true;
        }
        lvlButtons[0].interactable = true;
        lvlButtons[3].interactable = true;
        lvlButtons[6].interactable = true;
        for (int i = 0; i < LevelManager.Instance.GetLevelQuantity(); i++)
        {
            if (LevelManager.Instance.GetLevel(i).won)            
                if (i+1< LevelManager.Instance.GetLevelQuantity())                
                    lvlButtons[i+ 1].interactable = true;
        }

        if (PlayerPrefs.GetInt("LastWorld", 0) == 1)
        {
            SelectJungleWorld();
        }
        if (PlayerPrefs.GetInt("LastWorld", 0) == 2)
        {
            SelectFireWorld();
        }
        if (PlayerPrefs.GetInt("LastWorld", 0) == 3)
        {
            SelectIceWorld();
        }


    }

    public void SelectJungleWorld()
    {
        if (!jungleCentered)
        {
            PlayerPrefs.SetInt("LastWorld", 1);
            worldButtons[1].transform.SetSiblingIndex(2);
            worldButtons[0].transform.SetSiblingIndex(1);
            worldButtons[2].transform.SetSiblingIndex(0);
            worldBackgrounds[0].SetActive(true);
            worldLevelButtons[0].SetActive(true);
            worldBackgrounds[1].SetActive(false);
            worldLevelButtons[1].SetActive(false);
            worldBackgrounds[2].SetActive(false);
            worldLevelButtons[2].SetActive(false);
            jungleImage.sprite = worldButtonsSprites[0];
            fireImage.sprite = worldButtonsSprites[4];
            iceImage.sprite = worldButtonsSprites[5];
            jungleCentered = true;
            iceCentered = false;
            fireCentered = false;
        }


    }

    public void SelectFireWorld()
    {
        if (!fireCentered)
        {
            PlayerPrefs.SetInt("LastWorld", 2);
            worldButtons[0].transform.SetSiblingIndex(2);
            worldButtons[1].transform.SetSiblingIndex(1);
            worldButtons[2].transform.SetSiblingIndex(0);
            worldBackgrounds[0].SetActive(false);
            worldLevelButtons[0].SetActive(false);
            worldBackgrounds[1].SetActive(true);
            worldLevelButtons[1].SetActive(true);
            worldBackgrounds[2].SetActive(false);
            worldLevelButtons[2].SetActive(false);
            jungleImage.sprite = worldButtonsSprites[3];
            fireImage.sprite = worldButtonsSprites[1];
            iceImage.sprite = worldButtonsSprites[5];
            fireCentered = true;
            iceCentered = false;
            jungleCentered = false;
        }

    }

    public void SelectIceWorld()
    {
        if (!iceCentered)
        {
            PlayerPrefs.SetInt("LastWorld", 3);
            worldButtons[0].transform.SetSiblingIndex(0);
            worldButtons[1].transform.SetSiblingIndex(2);
            worldButtons[2].transform.SetSiblingIndex(1);
            worldBackgrounds[0].SetActive(false);
            worldLevelButtons[0].SetActive(false);
            worldBackgrounds[1].SetActive(false);
            worldLevelButtons[1].SetActive(false);
            worldBackgrounds[2].SetActive(true);
            worldLevelButtons[2].SetActive(true);
            jungleImage.sprite = worldButtonsSprites[3];
            fireImage.sprite = worldButtonsSprites[4];
            iceImage.sprite = worldButtonsSprites[2];
            iceCentered = true;
            fireCentered = false;
            jungleCentered = false;
        }

    }



    public void ResetPrefs()
    {
        //PlayerPrefs.DeleteAll();
        for (int i = 0; i < LevelManager.Instance.GetLevelQuantity(); i++)
        {
            LevelManager.Instance.SetLevelNotWon(i);
            LevelManager.Instance.SetStarNotTaken(i, 0);
            LevelManager.Instance.SetStarNotTaken(i, 1);
            LevelManager.Instance.SetStarNotTaken(i, 2);

        }
    }

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
