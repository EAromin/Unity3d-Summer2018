using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization
	public GameObject[] points;
	public float movementSpeed = 1f;
	List <Vector2> locations;
	private Rigidbody2D rb;
	private int counter = 0;
	void Start () {
		locations = new List<Vector2>();
		for(int i = 0; i < points.Length; i++){
				if(points[i]!=null)
			locations.Add(points[i].transform.position);

		}
		rb = transform.GetComponent<Rigidbody2D>();
	
	}
	void FixedUpdate(){
		Vector2 unitToTarget = (Vector2)rb.transform.position - locations[counter];
		float distanceToTarget = Mathf.Sqrt(Mathf.Abs((unitToTarget.x*unitToTarget.x) + (unitToTarget.y*unitToTarget.y)));
		if((locations[0]!=null)&&distanceToTarget < 0.1f)
			{
				counter = (counter+1)%locations.Count;
			//	Debug.Log("Target changed");
			}
		else{
				transform.position = Vector2.MoveTowards(transform.position,locations[counter],Time.deltaTime*movementSpeed);
			}
			//Debug.Log("Target: point " + counter+"\nVel:" + rb.velocity + "\nDistance to target:" + distanceToTarget);
			
	}

}