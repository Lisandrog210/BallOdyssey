using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour {
    [SerializeField] GameObject lvl1GO;
    Button lvl1Button;
    [SerializeField] GameObject lvl2GO;
    Button lvl2Button;
    [SerializeField] GameObject lvl3GO;
    Button lvl3Button;
    [SerializeField] GameObject lvl4GO;
    Button lvl4Button;


    private void Awake()
    {
        lvl1Button = lvl1GO.GetComponent<Button>();
        lvl1Button.interactable = true;
    }
}
