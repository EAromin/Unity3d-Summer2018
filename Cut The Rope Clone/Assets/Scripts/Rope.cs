using UnityEngine;

public class Rope : MonoBehaviour {

	// Use this for initialization
	public Rigidbody2D hook;

	public GameObject linkPrefab;
	public Weight endWeight;

	public int linkNum = 8;
	void Start () {
		GenerateRope ();
	}

	void GenerateRope(){

		Rigidbody2D previousLink = hook;
		for (int i = 0; i < linkNum; i++) {
			GameObject currentLink = Instantiate (linkPrefab, transform);
			HingeJoint2D joint = currentLink.GetComponent<HingeJoint2D> ();
			joint.connectedBody = previousLink;
			previousLink = currentLink.GetComponent<Rigidbody2D>();

		}


		endWeight.SetRopeEnd (previousLink.GetComponent <Rigidbody2D>());
	}

}
