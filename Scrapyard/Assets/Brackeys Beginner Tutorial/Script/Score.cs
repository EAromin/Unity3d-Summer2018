
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {

	// Use this for initialization
	public Transform player;
	public Text score;
	int currentScore = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		currentScore++;
		score.text = currentScore.ToString ("0");
	}
}
