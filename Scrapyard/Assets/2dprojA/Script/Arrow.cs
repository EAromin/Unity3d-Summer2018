
using UnityEngine;

public class Arrow : MonoBehaviour {

	// Update is called once per frame
	public Rigidbody2D rb;
	public Rigidbody2D parent;
	public float arrowOffset = 0.09f;
	public float shootPower = 25f;
	public bool fired = false;
	public PlayerControl pc;
	void Start(){
		fired = false;

	}
	void FixedUpdate () {
		if (!fired) {
			rb.transform.position = parent.transform.position + (parent.transform.up) * arrowOffset;
			rb.transform.rotation = parent.transform.rotation;
			rb.velocity = new Vector2 ();
		}
		if (Input.GetButtonDown ("Fire1") && !fired) {
			fired = true;
			//arrowOffset += 0.1f;
			rb.velocity =  (parent.transform.up *shootPower);
		}

		if (Input.GetButtonDown ("Fire2") && fired) {
			fired = false;
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			rb.velocity =  -(parent.transform.up *shootPower);

			//arrowOffset += 0.1f;
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (fired) {
			rb.constraints = RigidbodyConstraints2D.FreezeAll;
			
			pc.grounded = true;
		}
	}


}
