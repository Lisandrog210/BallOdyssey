using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouWinPanel : MonoBehaviour
{
    [SerializeField] GameObject[] coin;
    public Sprite starTaken;
    public Sprite starNotTaken;


    private void OnEnable()
    {
        Level level = LevelManager.Instance.GetLevel(StarsManager.Instance.GetLevelNumber());
        if (level.stars[0])
            coin[0].GetComponent<Image>().sprite = starTaken;
        else
            coin[0].GetComponent<Image>().sprite = starNotTaken;
        if (level.stars[1])
            coin[1].GetComponent<Image>().sprite = starTaken;
        else
            coin[1].GetComponent<Image>().sprite = starNotTaken;
        if (level.stars[2])
            coin[2].GetComponent<Image>().sprite = starTaken;
        else
            coin[2].GetComponent<Image>().sprite = starNotTaken;

    }


}
