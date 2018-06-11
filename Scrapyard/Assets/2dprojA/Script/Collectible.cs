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
	private float rotationSpeed = 1.0f;
	private bool touched = false;
	private SpriteRenderer s_rend;
	private Color spriteColor;
	void Start () {
		
		topLimit = rb.transform.position.y+ offset;
		bottomLimit = rb.transform.position.y-offset;
		s_rend = transform.gameObject.GetComponent<SpriteRenderer>();
		spriteColor = s_rend.color;
		
	
	}	
	
	// Update is called once per frame
	void Update(){
		
		if(touched){
			rotationSpeed = Mathf.Lerp(rotationSpeed, 20f,0.25f);
	
		}
		if(rotationSpeed > 15 &&spriteColor.a > 0)
				spriteColor.a -= 0.1f;
		s_rend.color = spriteColor;
	}
	void FixedUpdate () {
		if(rb.transform.position.y > topLimit)
			movingUp =false;
		else if(rb.transform.position.y < bottomLimit)
			movingUp = true;
		if(movingUp)
			rb.velocity = Vector2.MoveTowards(rb.transform.position,Vector2.up,10f) * animSpeed;
		else
			rb.velocity =  Vector2.MoveTowards(rb.transform.position,Vector2.up,10f) * -animSpeed;

		rb.transform.Rotate(Vector2.up * rotationSpeed,Space.World);

		if(spriteColor.a <0)
			Destroy(transform.gameObject);
	}

	void OnTriggerEnter2D(Collider2D collInfo){
		if(collInfo.tag == "Player")
		{
			
			touched = true;
			topLimit+=5f;
			animSpeed *=3;
		}
	}
}
