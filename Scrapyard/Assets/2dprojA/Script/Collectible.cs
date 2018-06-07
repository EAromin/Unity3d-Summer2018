using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

	// Use this for initialization
	public float offset = .05f;
	float bottomLimit,topLimit;
	public float animSpeed = 1.0f;
	Vector2 target;
	public Rigidbody2D rb;
	private bool movingUp = true;
	void Start () {
		
		topLimit = rb.transform.position.y+ offset;
		bottomLimit = rb.transform.position.y-offset;
	}	
	
	// Update is called once per frame
	void FixedUpdate () {
		if(rb.transform.position.y > topLimit)
			movingUp =false;
		else if(rb.transform.position.y < bottomLimit)
			movingUp = true;
		if(movingUp)
			rb.velocity = Vector2.MoveTowards(rb.transform.position,Vector2.up,10f) * animSpeed;
		else
			rb.velocity =  Vector2.MoveTowards(rb.transform.position,Vector2.up,10f) * -animSpeed;

		rb.transform.Rotate(Vector2.up,Space.World);
		Debug.Log(movingUp);
	}
}
