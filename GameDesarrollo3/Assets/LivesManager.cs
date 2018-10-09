using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour {

    GameObject ball;
    int _lives = 3;    

	void Start ()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        _lives = ball.GetComponent<WinLoseCheck>().lives;       

	}
	
	void Update ()
    {
        _lives = ball.GetComponent<WinLoseCheck>().lives;

        if (_lives == 2)
        {
            Destroy(GameObject.Find("Life0"));
            Debug.Log("Destroy1");
        }
        if (_lives == 1)
        {
            Destroy(GameObject.Find("Life1"));
            Debug.Log("Destroy2");
        }
        if (_lives == 0)
        {
            Destroy(GameObject.Find("Life2"));
            Debug.Log("Destroy3");
        }
    }
}
