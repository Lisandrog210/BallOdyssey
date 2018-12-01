using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldChange : MonoBehaviour
{
    public GameObject actualWorld;
    public GameObject actualWorldImage;
    [SerializeField]
    public GameObject[] otherWorlds;
    public GameObject[] otherWorldsImages;


    private void Awake()
    {       
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(ChangeWorld);
    }

    private void ChangeWorld()
    {
        actualWorld.SetActive(true);
        actualWorldImage.SetActive(true);
        for (int i = 0; i < otherWorlds.Length; i++)        
            otherWorlds[i].SetActive(false);
        for (int i = 0; i < otherWorldsImages.Length; i++)
            otherWorldsImages[i].SetActive(false);
    }
}

