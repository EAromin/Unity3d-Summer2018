
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {


	public float speed =2000f;
	public Rigidbody rb;
	void FixedUpdate () {
		//rb.AddForce (0,0,-speed * Time.deltaTime);
		rb.velocity = new Vector3 (0,0,-speed/50);
		if (gameObject.transform.position.z < -25f) {
			Destroy (gameObject);

		}
	}
}
