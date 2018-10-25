using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public GameObject player;
    public bool ZeroX = true;


    void LateUpdate()
    {
        Vector3 vec = Vector2.zero;
        if (!ZeroX)
        {
            vec.x = player.transform.position.x;
        }
        
        vec.y = player.transform.position.y;
        vec.z = -10.0f;
        transform.position = vec;
    }
}
