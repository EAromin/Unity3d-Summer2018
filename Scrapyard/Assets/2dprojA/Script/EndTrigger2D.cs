
using UnityEngine;

public class EndTrigger2D : MonoBehaviour {

	// Use this for initialization
	public GameObject endUI;
	void OnTriggerEnter2D(Collider2D collInfo){
		if(collInfo.tag =="Player"){
		transform.gameObject.GetComponent<Animator>().enabled = true;
		transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 99;
		Debug.Log("Triggered");
		endUI.SetActive(true);
		}
	}
}
