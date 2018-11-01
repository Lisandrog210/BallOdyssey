using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldChange : MonoBehaviour
{
    public GameObject actualWorld;
    [SerializeField]
    public GameObject[] otherWorlds;    


    private void Awake()
    {       
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(ChangeWorld);
    }

    private void ChangeWorld()
    {
        actualWorld.SetActive(true);
        for (int i = 0; i < otherWorlds.Length; i++)        
            otherWorlds[i].SetActive(false); 
    }
}

