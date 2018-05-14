
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
	public PlayerMovement movement;
	void OnCollisionEnter(Collision collisionInfo){
		if (collisionInfo.collider.tag == "Obstacle") {
			Debug.Log (collisionInfo.collider.name);
			movement.enabled = false;
			FindObjectOfType<GameManager> ().EndGame();
		}
		if (collisionInfo.collider.tag == "Ground") {
				movement.midAir = false;

		}	
	}

	void OnCollisionExit(Collision collisionInfo){
		if (collisionInfo.collider.tag == "Ground") {
			movement.midAir = true;

		}
	}
}
