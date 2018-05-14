
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public float speed = 2f;
	public Rigidbody2D rb;
	float x,y;
	// Update is called once per frame

	void Update(){
		rotateToMouse ();
	}
	void FixedUpdate () {
		ProcessInput ();
	}

	void ProcessInput(){
		
		y =   Input.GetAxisRaw("Vertical");
		x =   Input.GetAxisRaw("Horizontal");

		Vector2 newVel = Vector2.ClampMagnitude (new Vector2 (x, y), 1) * speed;
		rb.velocity = newVel;

	}

	void rotateToMouse(){
		Vector3 mousePos = Input.mousePosition;
		//set screen space to world space

		mousePos = Camera.main.ScreenToWorldPoint (mousePos);


		Vector2 dir = new Vector2 (mousePos.x - transform.position.x,mousePos.y - transform.position.y);

		transform.up = dir;

	}
}
