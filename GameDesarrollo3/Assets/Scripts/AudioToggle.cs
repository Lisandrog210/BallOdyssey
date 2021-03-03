using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class AudioToggle : MonoBehaviour
{

    Toggle myToggle;

    void Start()
    {
        myToggle = GetComponent<Toggle>();
        if (PlayerPrefs.GetInt("AudioOnOff") == 0)
        {
            myToggle.isOn = false;
            AudioListener.volume = 0;
        }
        else
        {
            myToggle.isOn = true;
            AudioListener.volume = 1;
        }              
    }

    public void ToggleAudioOnValueChange(bool audioIn)
    {
        if (audioIn)
        {
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("AudioOnOff", 1);
        }
        else
        {
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("AudioOnOff", 0);
        }
    }


}
