using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checkpoint : MonoBehaviour {

    public bool isActive = false;
    Animator torchAnimator;
    CheckpointManager cm;


	void Start ()
    {
        cm = GetComponentInParent<CheckpointManager>();
        torchAnimator = this.GetComponent<Animator>();
	}	
	
	void Update () {       
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Ball")
        {
            Debug.Log("me pego la bola");
            Activate();
        }
    }

    void Activate()
    {
        isActive = true;
        torchAnimator.SetTrigger("Touched");
        cm.lastActivated = this.gameObject;

    }

}
