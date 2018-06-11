using UnityEngine;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour {

	bool gameEnd = false;
	public float delay = 1f;
<<<<<<< HEAD
<<<<<<< HEAD
	public GameObject levelCompleteUI;
=======
>>>>>>> 47316ff6261a380fbe39b391607e31564cf1f08d
=======
>>>>>>> 47316ff6261a380fbe39b391607e31564cf1f08d
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
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
<<<<<<< HEAD
<<<<<<< HEAD

	void CompleteLevel(){

	}
=======
>>>>>>> 47316ff6261a380fbe39b391607e31564cf1f08d
=======
>>>>>>> 47316ff6261a380fbe39b391607e31564cf1f08d
}
