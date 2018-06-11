
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public float speed = 2f;
	public Rigidbody2D rb;
	float x,y;
	public Arrow arr;
	public Rope rope;
	public float jumpForce = 5f;
	public bool grounded = true;
	// Update is called once per frame

	void Update(){
		if (!arr.fired) {
			rotateToMouse ();
		} 

	}
	void FixedUpdate () {
		ProcessInput ();
	}

	void ProcessInput(){
		
		x =   Input.GetAxisRaw("Horizontal");


		if (Input.GetButtonDown("Jump") && grounded) {
			rb.velocity += new Vector2(0,jumpForce);
			grounded = false;
		
			if (arr.fired && arr.rb.constraints == RigidbodyConstraints2D.FreezeAll) {
				arr.fired = false;
				arr.rb.constraints = RigidbodyConstraints2D.FreezeRotation;

				rope.fired = false;
				foreach (Transform child in rope.transform)
					Destroy (child.gameObject);
				//arr.rb.velocity =  -(transform.up *arr.shootPower);
				}
			}
		if (x != 0)
			rb.velocity += new Vector2 (x, 0);
		else if (x == 0) {		
			
			if (rb.velocity.x > 0) {
				if(rb.velocity.x <= 0.1f)
					rb.velocity = new Vector2 (0f, rb.velocity.y);
				else
					rb.velocity += new Vector2 (-.2f, 0);
			} else if (rb.velocity.x < 0) {
				if(rb.velocity.x >= -0.1f)
					rb.velocity = new Vector2 (0f, rb.velocity.y);
				else
					rb.velocity += new Vector2 (.2f, 0);
			}
			
		}
		rb.velocity = new Vector2 (Mathf.Clamp (rb.velocity.x, -speed, speed), rb.velocity.y);

	}

	void rotateToMouse(){
		Vector3 mousePos = Input.mousePosition;
		//set screen space to world space

		mousePos = Camera.main.ScreenToWorldPoint (mousePos);


		Vector2 dir = new Vector2 (mousePos.x - transform.position.x,mousePos.y - transform.position.y);

		transform.up = dir;

	}
}
