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
<<<<<<< HEAD
<<<<<<< HEAD
	private float rotationSpeed = 1.0f;
	private bool touched = false;
	private SpriteRenderer s_rend;
	private Color spriteColor;
=======
>>>>>>> 47316ff6261a380fbe39b391607e31564cf1f08d
=======
>>>>>>> 47316ff6261a380fbe39b391607e31564cf1f08d
	void Start () {
		
		topLimit = rb.transform.position.y+ offset;
		bottomLimit = rb.transform.position.y-offset;
<<<<<<< HEAD
<<<<<<< HEAD
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
=======
	}	
	
	// Update is called once per frame
>>>>>>> 47316ff6261a380fbe39b391607e31564cf1f08d
=======
	}	
	
	// Update is called once per frame
>>>>>>> 47316ff6261a380fbe39b391607e31564cf1f08d
	void FixedUpdate () {
		if(rb.transform.position.y > topLimit)
			movingUp =false;
		else if(rb.transform.position.y < bottomLimit)
			movingUp = true;
		if(movingUp)
			rb.velocity = Vector2.MoveTowards(rb.transform.position,Vector2.up,10f) * animSpeed;
		else
			rb.velocity =  Vector2.MoveTowards(rb.transform.position,Vector2.up,10f) * -animSpeed;

<<<<<<< HEAD
<<<<<<< HEAD
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
=======
		rb.transform.Rotate(Vector2.up,Space.World);
		Debug.Log(movingUp);
>>>>>>> 47316ff6261a380fbe39b391607e31564cf1f08d
=======
		rb.transform.Rotate(Vector2.up,Space.World);
		Debug.Log(movingUp);
>>>>>>> 47316ff6261a380fbe39b391607e31564cf1f08d
	}
}
