using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuitButton : MonoBehaviour
{

    private void Awake()
    {
        var btn2 = GetComponent<Button>();
        btn2.onClick.AddListener(Close);

    }

    public void Close()
    {
        Application.Quit();
    }

}