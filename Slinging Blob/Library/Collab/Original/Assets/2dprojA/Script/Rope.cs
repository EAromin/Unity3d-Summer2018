
using UnityEngine;

public class Rope : MonoBehaviour {
	public GameObject linkPrefab;
	public int numOfLinks = 8;
	public Rigidbody2D hook;
	public HingeJoint2D otherHook;
	// Use this for initialization
	public bool fired = false;
	void Start () {
	//	GenerateLinks ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown ("Fire1") && !fired) {
			fired = true;
			//arrowOffset += 0.1f;
			GenerateLinks ();
		}

		if (Input.GetButtonDown ("Fire2") && fired) {
			fired = false;
			foreach (Transform child in transform)
				Destroy (child.gameObject);
		}
	}
	void GenerateLinks(){
	
		Rigidbody2D prev = hook;
		for (int i = 0; i < numOfLinks ; i++) {
			GameObject link = Instantiate (linkPrefab,transform);
			HingeJoint2D joint = link.GetComponent <HingeJoint2D> ();
			joint.connectedBody = prev;
			prev = link.GetComponent <Rigidbody2D> ();
		}
		otherHook.enabled = true;
		otherHook.connectedBody = prev;

	}
}
