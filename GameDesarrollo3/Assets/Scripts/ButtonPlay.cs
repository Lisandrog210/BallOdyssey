using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    [SerializeField] string nextLevel;
    GameObject backPanel;
    Scene activeScene;
    string aSceneName;

    private void Awake()
    {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(ChangeLevel);
        activeScene = SceneManager.GetActiveScene();
        aSceneName = activeScene.name;

        if (aSceneName == "Main Menu")
        {
            backPanel = GameObject.FindGameObjectWithTag("BackPanel");
        }

    }

    private void ChangeLevel()
    {
        if (aSceneName == "Main Menu")
        {
            if (backPanel.activeSelf == true)
                Application.Quit();
            else
            {
                SceneManager.LoadScene(nextLevel);
                Debug.Log("changing level");
            }
        }
        else
        {
            SceneManager.LoadScene(nextLevel);
            Debug.Log("changing level");
        }
    }
}

