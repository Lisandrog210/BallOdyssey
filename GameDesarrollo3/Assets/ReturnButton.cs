using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ReturnButton : MonoBehaviour
{

    [SerializeField] GameObject parentPanel;

    void Awake()
    {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(ReturnAndClose);
    }

    private void ReturnAndClose()
    {
        parentPanel.SetActive(false);        
    }
}
