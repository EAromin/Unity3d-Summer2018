using UnityEngine;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour {

	bool gameEnd = false;
	public float delay = 1f;
	public GameObject levelCompleteUI;
	// Use this for initialization
	public void EndGame () {
		if(!gameEnd)
		{
			gameEnd = true;
			Debug.Log("Game over");
			Invoke("Restart",delay);
			
		}
	}
	
	// Update is called once per frame
	void Restart () {
		Collectible.score = 0;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void CompleteLevel(){

	}
}
