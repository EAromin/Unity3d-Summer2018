using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
	bool gameEnd =false;
	public float restartDelay = 1f;
	public GameObject completeLevelUI;
	public void EndGame(){
		if (!gameEnd) {
			gameEnd = true;
			Debug.Log ("Game Over");
			Invoke ("Restart",restartDelay); 

		}
	}
	void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void CompleteLevel(){
		Debug.Log ("Game Won");
		completeLevelUI.SetActive (true);
	}
}
