using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checkpoint : MonoBehaviour {
        
    Animator torchAnimator;
    //CheckpointManager cm;

	void Start ()
    {
        //cm = GetComponentInParent<CheckpointManager>();
        torchAnimator = this.GetComponent<Animator>();
	}	
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Ball")                  
            Activate();
    }

    void Activate()
    {       
        torchAnimator.SetTrigger("Touched");               
        CheckpointManager.Instance.SetLastActivated(this.gameObject);
        CheckpointManager.Instance.SetLastActivatedComponent();
        StarsManager.Instance.ClearStarsList();
        this.gameObject.GetComponent<Collider2D>().enabled = false;
    }


}
