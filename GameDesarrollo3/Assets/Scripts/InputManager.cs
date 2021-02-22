using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    static InputManager instance = null;

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

    public float GetHorizontalAxis()
    {
        return input.GetHorizontalAxis();
    }

    public bool GetJumpButton()
    {
        return input.GetJumpButton();
    }

}