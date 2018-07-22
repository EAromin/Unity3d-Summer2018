
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 3f;
    bool isFocus,hasInteracted = false;
    Transform player;
	public Transform interactionTransform; // so that interaction point isn't necessarily on the object itself
	public virtual void Interact(){}
	void Update(){
		if(isFocus){
			float distance = Vector3.Distance(player.position,interactionTransform.position);
			if(distance<=radius && !hasInteracted){
				Interact();
				hasInteracted = true;
			}
		}
	}
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
    public void OnFocused(Transform playertrans)
    {
        isFocus = true; 
		player = playertrans;
		hasInteracted = false;
    }
	public void OnDefocused(){
		isFocus = false;
		player = null;
		hasInteracted = false;
	}
}
