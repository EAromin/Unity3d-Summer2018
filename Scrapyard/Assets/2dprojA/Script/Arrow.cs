
using UnityEngine;

public class Arrow : MonoBehaviour {

	// Update is called once per frame
	public Rigidbody2D rb;
	public Rigidbody2D parent;
	public float arrowOffset = 0.09f;
	bool fired = false;
	void FixedUpdate () {
		if(!fired)
			rb.transform.position = parent.transform.position + (parent.transform.up)*arrowOffset;
		rb.transform.rotation = parent.transform.rotation;
		if (Input.GetButtonDown ("Jump") && !fired) {
			fired = true;
			//arrowOffset += 0.1f;
			rb.velocity =  (parent.transform.up *1f);
		}
	}


}
