using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
           
    public delegate void PickUp();
    public static event PickUp OnPickedUp;

    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.gameObject.tag == "Ball") {
            this.gameObject.SetActive(false);
            OnPickedUp();
          
            
        }
    }

   

}
