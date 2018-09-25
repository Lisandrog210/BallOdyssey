using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public GameObject player;

    void LateUpdate()
    {
        Vector3 vec = Vector2.zero;
        //vec.x = 0f;
        vec.y = player.transform.position.y;
        vec.z = -10.0f;
        transform.position = vec;
    }
}
