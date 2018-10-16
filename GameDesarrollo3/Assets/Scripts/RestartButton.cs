using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour {

    private void Awake()
    {
        var btn2 = GetComponent<Button>();
        btn2.onClick.AddListener(Restart);

    }

    public void Restart()
    {
        
    }
}
