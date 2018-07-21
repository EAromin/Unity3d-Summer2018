using UnityEngine.UI;
using UnityEngine;

public class Score2D : MonoBehaviour {


public Text scorruh;
	// Update is called once per frame
	void Update () {
		scorruh.text = Collectible.score.ToString("0");
	}
}
