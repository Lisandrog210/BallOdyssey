using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour {    

    [SerializeField] WinLoseCheck winlose;

    private int score;
    public Text scoreText;

    void Start()
    {
        winlose.GetComponent<WinLoseCheck>();        
    }

    void Update()
    {
        score = winlose.grabbedCoins;
        scoreText.text = score.ToString();
    }
}
