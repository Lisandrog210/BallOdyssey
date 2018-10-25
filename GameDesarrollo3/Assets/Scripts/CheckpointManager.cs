using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    public GameObject lastActivated;
    CheckpointCoinReset ccr;
    private static CheckpointManager instance;

    public static CheckpointManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CheckpointManager>();
            }
            return instance;
        }
    }

    void Start()
    {
        lastActivated = null;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    public void SetLastActivated(GameObject gameObject)
    {
        lastActivated = gameObject;
    }

    public void ResetCoins()
    {
        StarsManager.Instance.ReDrawStars();
    }

    public void SetLastActivatedComponent()
    {
        ccr = lastActivated.GetComponent<CheckpointCoinReset>();
    }

   


}
