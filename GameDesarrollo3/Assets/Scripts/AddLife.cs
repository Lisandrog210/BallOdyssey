using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ExaGames.Common.TimeBasedLifeSystem;

public class AddLife : MonoBehaviour {

    GameObject player;
    WinLoseCheck wlc;
    LivesManager lm;

    [SerializeField] string nextLevel;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Ball");
        wlc = player.GetComponent<WinLoseCheck>();
        lm = GameObject.FindGameObjectWithTag("LifeManager").GetComponent<LivesManager>();
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(Add);
    }

    private void Add()
    {
        lm.GiveLives(1);
        //wlc.lives = wlc.lives + 1;
        SceneManager.LoadScene(nextLevel);        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
