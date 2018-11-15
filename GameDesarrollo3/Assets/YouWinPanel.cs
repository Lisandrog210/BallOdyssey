using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouWinPanelScript : MonoBehaviour
{
    [SerializeField] Image[] coinImage;

    private void OnEnable()
    {
        
        Level level = LevelManager.Instance.GetLevel(StarsManager.Instance.GetLevelNumber());
        Debug.Log(level.stars[0]);
        if (level.stars[0])
            coinImage[0].enabled = true;
        if (level.stars[1])
            coinImage[1].enabled = true;
        if (level.stars[2])
            coinImage[2].enabled = true;   
    }


}
