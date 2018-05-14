
using UnityEngine;

public class ChunkDeletion : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if (transform.childCount == 0)
			Destroy (transform.gameObject);
	}
}
