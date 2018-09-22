using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float XY_Speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody body = GetComponent<Rigidbody>();
        body.interpolation = RigidbodyInterpolation.Interpolate;
        float wantedPlayer_X = Input.GetAxis("Horizontal") * XY_Speed;
        float wantedPlayer_Y = Input.GetAxis("Vertical") * XY_Speed;

        Vector3 wantedMoveVector = new Vector3(wantedPlayer_X, wantedPlayer_Y, 0);
        transform.Translate(wantedMoveVector * Time.deltaTime);
	}
}
