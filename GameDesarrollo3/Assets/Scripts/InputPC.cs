using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPC : IInput
{
    public float GetHorizontalAxis()
    {
        return Input.GetAxis("Horizontal");
    }

    public bool GetJumpButton() 
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("space");
            return true;
           
        }
            
        else
            return false;
    }
}
