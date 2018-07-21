using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Vector3 offset= new Vector3(0,0,-1);
	public GameObject target;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (target!=null)
		transform.position = target.transform.position + offset;
	}
}
