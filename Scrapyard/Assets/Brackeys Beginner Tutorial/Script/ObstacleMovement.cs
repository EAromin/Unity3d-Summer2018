
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {


	public float speed =2000f;
	public Rigidbody rb;
	void FixedUpdate () {
		rb.AddForce (0,0,-speed * Time.deltaTime);
		if (gameObject.transform.position.z < -100)
			Destroy (gameObject);
	}
}
