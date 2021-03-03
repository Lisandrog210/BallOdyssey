using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    [SerializeField] string nextLevel;

    private void Awake()
    {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(Reset);
    }

    private void Reset()
    {       
        Debug.Log("changing level");
    }
}

