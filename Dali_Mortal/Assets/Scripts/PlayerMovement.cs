using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float player_X_Speed = 3f;
    public float player_Y_Speed = 3f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        float wantedPlayer_X = Input.GetAxis("Horizontal") * player_X_Speed;
        float wantedPlayer_Y = Input.GetAxis("Vertical") * player_Y_Speed;

        transform.Translate(wantedPlayer_X,wantedPlayer_Y,0);
	}
}
