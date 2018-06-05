
using UnityEngine;

public class Rope : MonoBehaviour {
	public GameObject linkPrefab;
	public int numOfLinks = 7;
	public Rigidbody2D hook;
	public HingeJoint2D otherHook;
	// Use this for initialization
	public bool fired = false;

	public LineRenderer lr;
	private  GameObject []links;
	void Start () {
	//	GenerateLinks ();
		lr.positionCount = numOfLinks +1;
		links = new GameObject[numOfLinks+1];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		lr.enabled = fired;

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
		
		for(int i =0; i < links.Length; i++)
		{	if(links[i]!=null)
			lr.SetPosition(i,links[i].transform.position);
		}
	}
	void GenerateLinks(){
	
		Rigidbody2D prev = hook;
		links[0] = hook.transform.parent.transform.gameObject;
		for (int i = 0; i < numOfLinks ; i++) {
			GameObject link = Instantiate (linkPrefab,transform);
			HingeJoint2D joint = link.GetComponent <HingeJoint2D> ();
			joint.connectedBody = prev;
			prev = link.GetComponent <Rigidbody2D> ();
			links[i+1] = link;
		}
		otherHook.enabled = true;
		otherHook.connectedBody = prev;

	}
}
