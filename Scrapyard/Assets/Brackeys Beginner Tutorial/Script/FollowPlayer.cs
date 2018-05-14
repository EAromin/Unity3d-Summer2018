
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform player;
	public Vector3 offset = new Vector3(0,1,-5);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = player.position + offset;
	}
}
