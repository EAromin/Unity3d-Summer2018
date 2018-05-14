
using UnityEngine;

public class TimeGame : MonoBehaviour {
	float roundStartTime;
	int waitTime;
	// Use this for initialization
	void Start () {
		print ("Try to guess when countdown at 0 then space.");
		SetNewRandomTime ();
	}
	
	// Update is called once per frame
	void Update () {
		//spacebar input
		if(Input.GetKeyDown (KeyCode.Space)){
			float playerWaitTime = Time.time - roundStartTime;
			float error = Mathf.Abs(waitTime - playerWaitTime);
			print ("Waited for " + playerWaitTime +
				"\nOff by " + error +" seconds.");
			SetNewRandomTime ();
		}

	}
	void SetNewRandomTime(){
		waitTime = Random.Range (5, 21);
		roundStartTime = Time.time;
		print (waitTime + " seconds.");
	}
}
