using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    static InputManager instance = null;
    Scene activeScene;
    string aSceneName;
    public GameObject backPanel;

    IInput input;

    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InputManager>();
            }

            return instance;
        }
    }

    // Use this for initialization
    void Awake()
    {
        activeScene = SceneManager.GetActiveScene();
        aSceneName = activeScene.name;
        if (aSceneName == "Main Menu")
        {
            backPanel = GameObject.FindGameObjectWithTag("BackPanel");
            backPanel.SetActive(false);
        }

        instance = this;        
        if (PlayerPrefs.GetInt("AudioOnOff") == 0)
            AudioListener.volume = 0;        
        else
            AudioListener.volume = 1;

        #if UNITY_ANDROID || UNITY_IOS
                input = new InputMobile();
        #else
                input = new InputPC();
        #endif
    }

    void Update()
    {
        if (aSceneName == "Main Menu")
        {
            if (Input.GetKeyDown(KeyCode.Escape) && backPanel.activeSelf)
                backPanel.SetActive(false);

            else if (Input.GetKeyDown(KeyCode.Escape) && !backPanel.activeSelf)
                backPanel.SetActive(true);
        }
        else if (aSceneName == "LevelSelect")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                SceneManager.LoadScene("Main Menu");
        }
        else if (aSceneName != "Settings") //Si la escena activa es algun nivel, abrir menu pausa ------
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                GameObject.FindGameObjectWithTag("UI").transform.Find("PauseButton").GetComponent<PauseButton>().OpenPausePanel();
        }        
    }

    public float GetHorizontalAxis()
    {
        return input.GetHorizontalAxis();
    }

    public bool GetJumpButton()
    {
        return input.GetJumpButton();
    }

}