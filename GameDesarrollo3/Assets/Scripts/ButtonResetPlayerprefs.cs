using System.Collections;
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

    public void resetYes()
    {
        PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt("AudioOnOff", 1);
        SceneManager.LoadScene("Main Menu");
    }

    public void resetNo()
    {
        ConfirmationGo.SetActive(false);
        MenuGo.SetActive(true);
    }
}

