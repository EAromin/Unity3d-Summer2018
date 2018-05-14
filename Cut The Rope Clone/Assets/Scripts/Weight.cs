using UnityEngine;

public class Weight : MonoBehaviour {
	public float distFromChain = .5f;
	public void SetRopeEnd(Rigidbody2D end){
		HingeJoint2D joint = gameObject.AddComponent <HingeJoint2D>();
		joint.autoConfigureConnectedAnchor = false;
		joint.connectedBody = end;
		joint.anchor = Vector2.zero;
		joint.connectedAnchor = new Vector2 (0f,-distFromChain);
	}
}
