using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour {

	public float chunkDistance = 10f;
	public GameObject[] chunks = new GameObject[5];
	int [] chunkRecord = new int[2]{-1,-1};
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GenerateObstacles ();
	}
	void GenerateObstacles(){
		int temp = transform.childCount;

		switch (temp) {
		case 0:
			{
				chunkRecord[0] = Random.Range (0,5);
				GameObject child0 = Instantiate(chunks[chunkRecord[0]],transform);
				child0.transform.position = transform.position + new Vector3 (child0.transform.position.x, child0.transform.position.y, chunkDistance);

				chunkRecord [1] = Random.Range (0, 5);
				GameObject child1 = Instantiate (chunks[chunkRecord[1]],transform);
			
				child1.transform.position = transform.position + new Vector3 (child1.transform.position.x, child1.transform.position.y, chunkDistance*2);
				break;
			}

		case 1:
			{
				chunkRecord [0] = chunkRecord [1];
				chunkRecord [1] = Random.Range (0,5);
				GameObject child1 = Instantiate (chunks[chunkRecord[1]],transform);

				child1.transform.position = transform.position + new Vector3 (child1.transform.position.x, child1.transform.position.y, chunkDistance*2);
				break;
			}
		}
	}

}
