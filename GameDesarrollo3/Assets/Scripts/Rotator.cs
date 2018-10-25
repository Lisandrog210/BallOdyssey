using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    [SerializeField] private float rotationSpeed = 1f; 

	void Update ()
    {
       transform.Rotate(Vector3.forward * rotationSpeed,Space.Self);
    }
}

