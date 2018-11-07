using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExaGames.Common.TimeBasedLifeSystem;

public class AddLife : MonoBehaviour {

    GameObject player;
    WinLoseCheck wlc;
    LivesManager lm;
    GameObject moreLivesPanel;

    private void Awake()
    {
        moreLivesPanel = GameObject.FindGameObjectWithTag("MoreLivesPanel");
        player = GameObject.FindGameObjectWithTag("Ball");
        wlc = player.GetComponent<WinLoseCheck>();
        lm = GameObject.FindGameObjectWithTag("LifeManager").GetComponent<LivesManager>();
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(Add);
    }

    private void Add()
    {
        lm.GiveLives(1);
        moreLivesPanel.SetActive(false);
        player.GetComponent<MoveToCheckpoint>().Move();        
    }


}
