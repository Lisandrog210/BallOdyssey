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
    public GameObject jungle;
    public GameObject fire;
    public GameObject ice;
    public GameObject leftPosition;
    public GameObject centerPosition;
    public GameObject rightPosition;
    public Sprite[] buttonImages;
    /*private Image fireImage;
    private Image iceImage;
    private Image jungleImage;*/



    private void Awake()
    {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(ChangeWorld);
        /* fireImage = fire.GetComponent<Image>();
         iceImage = ice.GetComponent<Image>();
         jungleImage = jungle.GetComponent<Image>();*/
    }

    private void ChangeWorld()
    {
        actualWorld.SetActive(true);
        actualWorldImage.SetActive(true);
        for (int i = 0; i < otherWorlds.Length; i++)
            otherWorlds[i].SetActive(false);
        for (int i = 0; i < otherWorldsImages.Length; i++)
            otherWorldsImages[i].SetActive(false);

        this.transform.position = centerPosition.transform.position;
        if (this.gameObject == jungle.gameObject)
        {
            ice.transform.position = leftPosition.transform.position;
            fire.transform.position = rightPosition.transform.position;
        }
        if (this.gameObject == fire.gameObject)
        {
            ice.transform.position = leftPosition.transform.position;
            jungle.transform.position = rightPosition.transform.position;
        }
        if (this.gameObject == ice.gameObject)
        {
            jungle.transform.position = leftPosition.transform.position;
            fire.transform.position = rightPosition.transform.position;
        }
    }
}

