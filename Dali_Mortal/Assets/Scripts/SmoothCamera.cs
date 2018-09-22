using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour {
    
    public Transform target;

    Vector3 velocity = Vector3.zero;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;


    float changedFOW;

    PlayerSpeed player;

	void LateUpdate()
    {


        if (target)
        {
            
            Vector3 desiredPosition = target.position + offset;

            Vector3 FinalPos = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
            transform.position = FinalPos;

            transform.LookAt(target);


        }
    }
}
