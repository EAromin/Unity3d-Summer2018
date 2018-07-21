
using UnityEngine;

public class EndTrigger2D : MonoBehaviour {

	// Use this for initialization
	public GameObject endUI;
	private Animator anim;
	void Start(){
		anim = transform.gameObject.GetComponent<Animator>();

	}
	void OnTriggerEnter2D(Collider2D collInfo){
		if(collInfo.tag =="Player"){
			//anim.enabled = true;
			anim.SetBool("triggered", true);
	//	transform.gameObject.GetComponent<Animator>().enabled = true;
		transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 99;
		Debug.Log("Triggered");
		endUI.SetActive(true);
		}
	}
}
