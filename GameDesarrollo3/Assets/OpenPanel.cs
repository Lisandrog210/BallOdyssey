using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenPanel : MonoBehaviour
{

    [SerializeField] GameObject panelToOpen;

    void Awake()
    {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(PanelOpen);
    }

    private void PanelOpen()
    {
        panelToOpen.SetActive(true);
    }
}
