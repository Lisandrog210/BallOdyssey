using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPC : IInput
{
    public float GetHorizontalAxis()
    {
        return Input.GetAxis("Horizontal");
    }

}
