using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCoinReset : MonoBehaviour {

    public GameObject[] coinArray;
    GameObject starManager;
    public StarsManager smClass;
    public Level level;


    void Start ()
    {
        starManager = GameObject.FindGameObjectWithTag("StarManager");
        smClass = starManager.GetComponent<StarsManager>();
        level = LevelManager.Instance.GetLevel(smClass.levelNumb);

        for (int i = 0; i < coinArray.Length; i++)
        {
            if (level.stars[i])
            {
                if (!level.won)
                    ReactivateCoins();
                
            }
        }    
        
    }
	
	void Update ()
    {
       
	}

    public void ReactivateCoins()
    {
        //Debug.Log("Reactivate Coins1");
        for (int i = 0; i < coinArray.Length; i++)
        {
            //Debug.Log("Reactivate Coins2");
            if (coinArray[i].activeSelf == false)
            {
                //Debug.Log("Reactivate Coins3");
                coinArray[i].SetActive(true);
            }
        }

        
    }

}
