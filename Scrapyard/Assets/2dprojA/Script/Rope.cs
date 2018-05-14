
using UnityEngine;

public class Rope : MonoBehaviour {
	public GameObject linkPrefab;
	public int numOfLinks = 8;
	public Rigidbody2D hook;
	// Use this for initialization
	void Start () {
		GenerateLinks ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void GenerateLinks(){
	
		Rigidbody2D prev = hook;
		for (int i = 0; i < numOfLinks; i++) {
			GameObject link = Instantiate (linkPrefab,transform);
			HingeJoint2D joint = link.GetComponent <HingeJoint2D> ();
			joint.connectedBody = prev;

			prev = link.GetComponent <Rigidbody2D> ();
		}
	}
}
