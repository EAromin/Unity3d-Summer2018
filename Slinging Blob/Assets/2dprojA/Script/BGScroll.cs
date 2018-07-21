using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{

    // Use this for initialization
    public float bgSize;
    private Transform cameraTransform;
    private Transform[] children;
    private int left, right;
	public float viewZone,parallaxSpeed = 10f;
	private float lastCamX;

    void Start()
    {
        cameraTransform = Camera.main.transform;
		lastCamX = cameraTransform.position.x;
        children = new Transform[transform.childCount];
        for (int i = 0; i < children.Length; i++)
            {children[i] = transform.GetChild(i);
					Debug.Log(children[i].position.x );

			}
        left = 0;
        right = children.Length - 1;

    }

    // Update is called once per frame
    void Update()
    {
		float deltaX = cameraTransform.position.x - lastCamX;
		transform.position+=Vector3.right * deltaX * parallaxSpeed;
		lastCamX = cameraTransform.position.x;
		
        if (cameraTransform.position.x < (children[left].transform.position.x + viewZone))
            Scroll(0);
        if (cameraTransform.position.x > (children[right].transform.position.x - viewZone))
            Scroll(1);
    }

    private void Scroll(int posneg)
    {
        switch (posneg)
        {
            case 0:
                {
                    int lr = right;
                    children[right].position = new Vector3((children[left].position.x - bgSize),children[left].position.y,children[left].position.z);
                    left = right;
                    right--;
                    if (right < 0)
                        right = children.Length - 1;

                    break;
                }
            case 1:
                {
                    int ll = left;
                    children[left].position =  new Vector3((children[right].position.x + bgSize),children[right].position.y,children[right].position.z);
                    right = left;
                    left++;
                    if (left == children.Length)
                        left = 0;
                    break;
                }
        }
    }
}
