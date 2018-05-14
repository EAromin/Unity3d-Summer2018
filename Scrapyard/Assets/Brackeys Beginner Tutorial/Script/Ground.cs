
using UnityEngine;

public class Ground : MonoBehaviour {
	public Transform player;
	public Vector3  offset = new Vector3 (0,-1,-5);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float y = player.position.y + offset.y; 
		float z = player.position.z + offset.z;
		offset = new Vector3 (offset.x, y, z); 
	}
}
