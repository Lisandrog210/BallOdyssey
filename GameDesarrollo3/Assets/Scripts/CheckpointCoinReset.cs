using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCoinReset : MonoBehaviour 
{   
    public Level level;
    public List<GameObject> stars = new List<GameObject>();

    void Start ()
    {
        for (int i = 0; i < 3; i++)       
            stars.Add(StarsManager.Instance.GetStarsArray(i));
    }
	
    public void ReactivateCoins()
    {
        
    }

}
