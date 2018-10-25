using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPanel : MonoBehaviour {

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void Destroy()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

}
