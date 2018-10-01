using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldChange : MonoBehaviour
{
    public GameObject actualWorld;
    public GameObject otherWorld1;


    private void Awake()
    {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(ChangeWorld);
    }

    private void ChangeWorld()
    {
        actualWorld.SetActive(true);
        otherWorld1.SetActive(false);
    }
}

