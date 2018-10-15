using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExaGames.Common.TimeBasedLifeSystem;

public class UIManager : MonoBehaviour {

    GameObject lm;
    [SerializeField] LivesManager livesManager;
    int lives;

    void awake() {
        lm = GameObject.FindGameObjectWithTag("LifeManager");
        livesManager = lm.GetComponent<LivesManager>();
       
    }    

    public void ConsumeLife() {
        livesManager.ConsumeLife();
    }

}
