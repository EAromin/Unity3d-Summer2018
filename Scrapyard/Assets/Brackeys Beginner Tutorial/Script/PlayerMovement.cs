
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody rb;
	public float speed = 4000f;
	public float sideForce = 50f;
	bool moveLeft = false;
	bool moveRight = false;
	public float jumpHeight = 30f;
	public bool midAir = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	//you want fixedupdate for physics relatedstuff
	void FixedUpdate () {
		//rb.AddForce (0,0,speed * Time.deltaTime);
		InputFeedback ();
		if (rb.position.y < -1f) {
			FindObjectOfType<GameManager> ().EndGame ();
		}

		if (midAir) {
		//	Debug.Log ("MidAir");

				rb.AddForce (0, -sideForce * Time.deltaTime, 0, ForceMode.VelocityChange);

		}
		//else
		//	Debug.Log ("Grounded");
	}

	void Update(){
		ProcessInput ();
	}
	//for inputs
	void ProcessInput(){
		if (Input.GetKey ("d")) {
			moveRight = true;
		}
		if (Input.GetKey ("a")) {
			moveLeft = true;
		}

		//set to false

	}

	void InputFeedback(){
		if(moveLeft)
			rb.AddForce (-sideForce * Time.deltaTime,0,0,ForceMode.VelocityChange);
		if(moveRight)
			rb.AddForce (sideForce * Time.deltaTime,0,0,ForceMode.VelocityChange);
		if (Input.GetKey ("space") && !midAir) {
			midAir = true;
			rb.AddForce (0, sideForce * Time.deltaTime*jumpHeight, 0, ForceMode.VelocityChange);
		}
		moveRight = moveLeft = false;
		
	}


}
