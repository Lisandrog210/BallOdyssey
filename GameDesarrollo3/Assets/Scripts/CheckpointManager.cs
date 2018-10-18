using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour {
        
    public GameObject lastActivated;
    CheckpointCoinReset ccr;

	void Start () {
        lastActivated = null;
	}

    void Update()
    {
        if (lastActivated)
        {
            ccr = lastActivated.GetComponent<CheckpointCoinReset>();
        }
        
    }

    public void ResetCoins()
    {
        Debug.Log("ResetCoins");
        ccr.ReactivateCoins();
    }
}
