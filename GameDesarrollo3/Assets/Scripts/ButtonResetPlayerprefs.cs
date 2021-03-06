﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonResetPlayerprefs : MonoBehaviour
{
    public GameObject ConfirmationGo;
    public GameObject MenuGo;

    public void ResetConfirmationText()
    {
        MenuGo.SetActive(false);
        ConfirmationGo.SetActive(true);
    }

    public void ResetYes()
    {
      
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("HasBeenReseted", 1);
        PlayerPrefs.SetInt("AudioOnOff", 1);        
        SceneManager.LoadScene("Main Menu");
    }

    public void ResetNo()
    {
        ConfirmationGo.SetActive(false);
        MenuGo.SetActive(true);
    }
}

