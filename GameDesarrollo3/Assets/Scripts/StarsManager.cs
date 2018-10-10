using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsManager : MonoBehaviour {
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public bool isStar1Taken;
    public bool isStar2Taken;
    public bool isStar3Taken;

    public void Awake()
    {
        if (isStar1Taken)
            star1.gameObject.SetActive(false);
        if (isStar2Taken)
            star2.gameObject.SetActive(false);
        if (isStar3Taken)
            star3.gameObject.SetActive(false);
    }
   
    void Update () {
        Debug.Log("isstar1taken"+isStar1Taken);
        LevelSelectManager.instance.SetStars(3, isStar1Taken, isStar2Taken, isStar3Taken);
    }
}
