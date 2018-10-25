using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{

    GameObject ball;
    int? _lives = 3;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        _lives = ball.GetComponent<WinLoseCheck>().lives;

    }

    void Update()
    {
        _lives = ball.GetComponent<WinLoseCheck>().lives;

        if (_lives == 2)
            Destroy(GameObject.Find("Life2"));

        if (_lives == 1)
            Destroy(GameObject.Find("Life1"));

        if (_lives == 0)
            Destroy(GameObject.Find("Life0"));

    }
}
