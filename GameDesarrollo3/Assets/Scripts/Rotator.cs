using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    [SerializeField] private float rotationSpeed = 60f; 

	void Update ()
    {
        Debug.Log(rotationSpeed);
       transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.Self);
    }
}

