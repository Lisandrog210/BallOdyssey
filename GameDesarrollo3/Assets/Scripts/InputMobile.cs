using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMobile : IInput
{
    public bool GetFireButton()
    {
        return Input.touchCount > 0;
    }

    public float GetHorizontalAxis()
    {
        return Input.acceleration.x;
    }

}
