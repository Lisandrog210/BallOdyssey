using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    [SerializeField] string nextLevel;

    private void Awake()
    {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(ChangeLevel);
    }

    private void ChangeLevel()
    {
        SceneManager.LoadScene(nextLevel);
        Debug.Log("changing level");
    }
}

