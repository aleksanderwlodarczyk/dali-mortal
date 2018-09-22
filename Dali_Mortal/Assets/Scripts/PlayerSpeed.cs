using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeed : MonoBehaviour {

    public float defaultSpeed = 1f;
    public float playerAcceleration = 2f;

    public Vector3 velo = new Vector3(0,0,1);
    public Vector3 currentVelo = new Vector3(0, 0, 1);
    public Vector3 acceleration = new Vector3(0, 0, 2);
    public Vector3 accVelo = new Vector3(0, 0, 10); 

    Rigidbody rb;
    float currentVelocity;

    float defaultPlayerLength;
    float defaultPlayerWidth;

    float playerLength;
    float playerWidth;
    
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        currentVelocity = defaultSpeed;
    }


	// Update is called once per frame
	void Update () {
        
        
        if(!Input.GetKey("space")){


            if (rb.velocity.z > defaultSpeed)
            {
                Debug.Log("current velo is bigger than default speed");
                currentVelo.z = Time.deltaTime * -playerAcceleration;
                rb.velocity -= currentVelo;
            }
            
                rb.velocity = velo;
            
            
            Debug.Log("No space");
        }
        if (Input.GetKey("space"))
        {
            if (rb.velocity.z <= accVelo.z)
            {
                Debug.Log("Space");
                currentVelo.z = Time.deltaTime * playerAcceleration;
                rb.velocity += currentVelo;
            }
            
            
        }

        changeLength();




    }

    void changeLength()
    {
        rb = GetComponent<Rigidbody>();

        //currentVelocity = rb.velocity.magnitude;

        Debug.Log("Current velocity is: " + rb.velocity.z);

    }




}
