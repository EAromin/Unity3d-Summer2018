using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    Camera camera;
    PlayerMotor motor;
    public LayerMask moveMask;
    // Use this for initialization
    void Start()
    {
        camera = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //if we hit anything with the ray we casted by clicking
            if (Physics.Raycast(ray, out hit, 100, moveMask))
            {
                motor.MoveToPoint(hit.point);
            }
        }
		//right click, focus on interactables
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //if we hit anything with the ray we casted by clicking
            if (Physics.Raycast(ray, out hit, 100, moveMask))
            {
                
            }
        }
    }
}
