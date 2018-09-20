using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public GameObject player;
   


    void LateUpdate()
    {
        Vector3 blahblah = Vector2.zero;
        blahblah.x = 0f;
        blahblah.y = player.transform.position.y;
        blahblah.z = -10.0f;
        transform.position = blahblah;
    }
}
