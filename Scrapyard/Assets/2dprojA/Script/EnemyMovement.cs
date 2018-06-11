using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization
	public GameObject[] points;
	List <Vector3> locations;
	void Start () {
		for(int i = 0; i < points.Length; i++){
			locations.Add(points[i].transform.position);
		
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}