using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputMobile : IInput
{
    
    public float GetHorizontalAxis()
    {
        return Input.acceleration.x;
    }

    public bool GetJumpButton() 
    {
        return Input.GetMouseButtonDown(0);
    }
}
