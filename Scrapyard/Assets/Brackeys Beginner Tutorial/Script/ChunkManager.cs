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
		Vector3 ransign = new Vector3(RandomSign (),1,1);

		switch (temp) {
		case 0:
			{
				chunkRecord[0] = Random.Range (0,5);
				GameObject child0 = Instantiate(chunks[chunkRecord[0]],transform);
				child0.transform.position = transform.position + new Vector3 (child0.transform.position.x, child0.transform.position.y, chunkDistance);

				chunkRecord [1] = Random.Range (0, 5);
				GameObject child1 = Instantiate (chunks[chunkRecord[1]],transform);
			
				child1.transform.position = transform.position + new Vector3 (child1.transform.position.x, child1.transform.position.y, chunkDistance*3);
				if (chunkRecord [0] == 4)
					//child0.transform.localScale = new Vector3 (RandomSign (),child0.transform.localScale.y,child0.transform.localScale.z);
					child0.transform.localScale = ransign;
				else
					ChangeX (ref child0);
				ransign = new Vector3(RandomSign (),1,1);
				if (chunkRecord [1] == 4)
					child1.transform.localScale = ransign;
				else
					ChangeX (ref child1);
				break;
			}

		case 1:
			{
				chunkRecord [0] = chunkRecord [1];
				chunkRecord [1] = Random.Range (0,5);
				GameObject child1 = Instantiate (chunks[chunkRecord[1]],transform);
				ransign = new Vector3(RandomSign (),1,1);
				child1.transform.position = transform.position + new Vector3 (child1.transform.position.x, child1.transform.position.y, chunkDistance*3);
				if (chunkRecord [1] == 4)
					child1.transform.localScale = ransign;
				else
					ChangeX (ref child1);
				break;
			}
		}
	}

	int RandomSign(){
		int temp = Random.Range (0,2);
		if (temp ==1)
			return 1;
		return -1;
	}

	void ChangeX(ref GameObject x){
		x.transform.position += new Vector3((RandomSign()*((float)Random.Range (0, 100))/20),0,0);
	}
}
