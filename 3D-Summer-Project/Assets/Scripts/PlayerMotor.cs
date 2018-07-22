using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {

	// Use this for initialization
	NavMeshAgent agent;
	Transform target;
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	void Update(){
		if(target != null){
			agent.SetDestination(target.position);
			FaceTarget();
		}
	}
	public void MoveToPoint(Vector3 point){
		agent.SetDestination(point);
	}
	public void FollowTarget(Interactable newTarget){
		agent.stoppingDistance = newTarget.radius * 0.8f;
		agent.updateRotation = false;
		target = newTarget.interactionTransform;
	}
	public void StopFollowingTarget(){
		agent.stoppingDistance = 0f;
		agent.updateRotation = true;
		target = null;
	}

	void FaceTarget(){
		Vector3 dir = (target.position - transform.position).normalized;
		Quaternion lookRot = Quaternion.LookRotation(new Vector3(dir.x,0,dir.z));
		transform.rotation = Quaternion.Slerp(transform.rotation,lookRot,Time.deltaTime * 5f);
	}
}
