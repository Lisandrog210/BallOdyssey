using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetPlayerPrefs : MonoBehaviour {

	
	void Awake () {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(ResetGame);
    }

    private void ResetGame()
    {
        LevelSelectButtons.Instance.ResetPrefs();
        SceneManager.LoadScene("Main Menu");           
    }


}
