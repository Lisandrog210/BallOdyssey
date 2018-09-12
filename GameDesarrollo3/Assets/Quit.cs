using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quit : MonoBehaviour
{

    public void Awake()
    {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(Close);

    }

    public void Close()
    {
        Application.Quit();
    }

}