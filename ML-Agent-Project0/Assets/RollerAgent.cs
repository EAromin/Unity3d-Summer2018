using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerAgent : Agent
{

	Rigidbody rb;

	void Start ()
	{
		rb = GetComponent <Rigidbody> ();
	}

	public Transform target;

	public override void AgentReset ()
	{
	
		if (this.transform.position.y <= -1.0) {
			//ball falling off
			this.transform.position = this.rb.angularVelocity = this.rb.velocity = Vector3.zero;
		
		} else {
			target.position = new Vector3 (Random.value * 8 - 4, 0.5f, Random.value * 8 - 4);
		}
	}

	public override void CollectObservations ()
	{
		//dist between target and agent
		Vector3 relativePos = target.position - this.transform.position;

		//Calculations below are divided by 5 because of the 10 by 10 plane, we want to normalize the data to [-1,1]
		AddVectorObs (relativePos.x / 5);
		AddVectorObs (relativePos.z / 5);

		//confines of the platform
		/*AddVectorObs ((this.transform.position.x + 5) / 5);
		AddVectorObs ((this.transform.position.x - 5) / 5);
		AddVectorObs ((this.transform.position.z + 5) / 5);
		AddVectorObs ((this.transform.position.z - 5) / 5);
*/
		AddVectorObs (this.transform.position.x / 5);
		AddVectorObs (this.transform.position.z / 5);
		AddVectorObs (rb.velocity.x/5);
		AddVectorObs (rb.velocity.z/5);
	}

	//actions. The vecor size depends on the different possible decisions that a brain can execute at runtime. Left,Right,Jump? size=3
	//for our ball, we will  have a vector action size of two, since it's moving along a plane. The only relevant movement would be a mix of different x's and z's

	public float speed = 10; 
	private float prevDist = float.MaxValue;

	public override void AgentAction(float[] vectorAction, string textAction){

		float distanceToTarget = Vector3.Distance (this.transform.position,target.position);
		//reach target
		if(distanceToTarget < 1.42f)
		{
			Done ();
			AddReward (1.0f);
		}

		//closer
		if (distanceToTarget < prevDist) {
			AddReward (0.1f);
		}

		//time penalty 
		AddReward (-0.15f);

		//falls off
		if (this.transform.position.y < -1.0f) {
			Done ();
			AddReward (-1.0f);
		}

		//update distance
		prevDist = distanceToTarget;

		//Actions
		Vector3 controlSignal = Vector3.zero;
		controlSignal.x = Mathf.Clamp (vectorAction [0], -1, 1);
		controlSignal.z = Mathf.Clamp (vectorAction [1], -1, 1);
		rb.AddForce (controlSignal * speed);
	}

}
