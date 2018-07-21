using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    private float zoom = 10f;
	public float pitch = 2f;
	public float zoomRate = 4f;
	public float minZoom = 5f;
	public float maxZoom = 15f;

	public float yawRate = 100f;
	private float yawInput = 0f;
	void Update(){
		zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomRate;
		zoom = Mathf.Clamp(zoom,minZoom,maxZoom);

		yawInput -= Input.GetAxis("Horizontal") * yawRate * Time.deltaTime;
	}
    void LateUpdate()
    {
		//Acts just like Update, once per turn, but is called after update
		transform.position = target.position - offset * zoom;
		transform.LookAt(target.position+ Vector3.up *pitch);

		transform.RotateAround(target.position,Vector3.up,yawInput);

    }
}
