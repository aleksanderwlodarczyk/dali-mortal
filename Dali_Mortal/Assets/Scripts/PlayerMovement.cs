using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float XY_Speed;
	// Update is called once per frame
	void Update () {
        Rigidbody body = GetComponent<Rigidbody>();
        body.interpolation = RigidbodyInterpolation.Interpolate;

        
            float wantedPlayer_X = Input.GetAxis("Horizontal") * XY_Speed;
            float wantedPlayer_Y = Input.GetAxis("Vertical") * XY_Speed;

            Vector3 wantedMoveVector = new Vector3(wantedPlayer_X, wantedPlayer_Y, 0);

        transform.position += wantedMoveVector * Time.deltaTime * 1;

        //Vector2 minimumlampingArea = new Vector2(-10, -10);
        Vector3 clampingArea = new Vector3(-10, 10,0);
        Vector3 clampedPosition = transform.position;
        //clampingArea = transform.position;

        clampedPosition.x = Mathf.Clamp(transform.position.x, clampingArea.x, clampingArea.y);
        clampedPosition.y = Mathf.Clamp(transform.position.y, clampingArea.x, clampingArea.y);

        transform.position = clampedPosition;
        Debug.Log("X = " + transform.position.x + "Y = " + transform.position.y + "Z = " + transform.position.z);
    }
}
