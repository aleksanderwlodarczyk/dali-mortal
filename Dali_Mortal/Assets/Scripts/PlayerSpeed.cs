using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeed : MonoBehaviour {

    public float defaultSpeed = 1f;
    public float playerAcceleration = 2f;

    public Vector3 velo = new Vector3(0,0,1);
    public Vector3 currentVelo = new Vector3(0, 0, 1);
    public Vector3 accVelo = new Vector3(0, 0, 10); 

    Rigidbody rb;
    public float currentVelocity;

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
        
        
        
        if (Input.GetKey("space"))
        {
            if (rb.velocity.z <= accVelo.z)
            {
                Debug.Log("Space");
                currentVelo.z = Time.deltaTime * playerAcceleration;
                rb.velocity += currentVelo;
            }
            
            
        }
        if (!Input.GetKey("space"))
        { //If there's no space pushed


            if (rb.velocity.z > velo.z) //If there's velocity higher than start velocity
            {
                Debug.Log("current velo is bigger than default speed");
                currentVelo.z = -1 * Time.deltaTime * playerAcceleration;
                rb.velocity += currentVelo;

            }
            else { 
            rb.velocity = velo; //Translating the object with constant value
        }
            
                    Debug.Log("No space");
                }
        changeLength();




    }

    void changeLength()
    {
        rb = GetComponent<Rigidbody>();

		currentVelocity = rb.velocity.z;

        Debug.Log("Current velocity is: " + rb.velocity.z);

    }




}
