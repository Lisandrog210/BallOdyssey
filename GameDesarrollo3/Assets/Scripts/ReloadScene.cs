using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour {
    Scene scene;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(Reload);
    }

    private void Reload()
    {
        SceneManager.LoadScene(scene.name);
        Debug.Log("changing level");
    }
}
