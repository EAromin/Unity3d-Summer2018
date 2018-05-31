
using UnityEngine;

public class Arrow : MonoBehaviour {

	// Update is called once per frame
	public Rigidbody2D rb;
	public Rigidbody2D parent;
	public float arrowOffset = 0.09f;
	public bool fired = false;
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
			rb.velocity =  (parent.transform.up *20f);
		}

		if (Input.GetButtonDown ("Fire2") && fired) {
			fired = false;
			rb.velocity =  -(parent.transform.up *20f);

			//arrowOffset += 0.1f;
		}
	}


}
