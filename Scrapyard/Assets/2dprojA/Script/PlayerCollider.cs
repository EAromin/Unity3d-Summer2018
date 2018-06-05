using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {

	public PlayerControl pc;
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D coll){
		pc.grounded = true;

		if(coll.collider.tag == "Spike"){
			pc.enabled = false;
			FindObjectOfType<GManager>().EndGame();
			Destroy(this.gameObject);

		}
	}
	void OnCollisionExit2D(Collision2D coll){
		

	}


}