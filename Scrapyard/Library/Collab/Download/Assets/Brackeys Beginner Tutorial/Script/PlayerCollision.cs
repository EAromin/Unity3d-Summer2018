
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
	public PlayerMovement movement;
	void OnCollisionEnter(Collision collisionInfo){
		if (collisionInfo.collider.tag == "Obstacle") {
			//movement.enabled = false;
			//FindObjectOfType<GameManager> ().EndGame();
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
