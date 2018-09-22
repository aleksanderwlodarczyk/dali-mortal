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

    public float defaultPlayerWidth = 1.87f;

    Vector3 scale;

    public float defaultCameraFOW = 45;
    public float cameraFOWConstant = 10f;
    
    private float currentCameraFOW;

    public float minScale = 0.2f;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        currentVelocity = defaultSpeed;
        scale = new Vector3(0.5f, 0.5f, -1f);
        currentCameraFOW = defaultCameraFOW;
    }


	// Update is called once per frame
	void Update () {


        //currentCameraFOW = (currentVelocity / defaultSpeed) * defaultCameraFOW;

        currentCameraFOW = 2.33f * currentVelocity + 33.3f;

        Camera.main.fieldOfView = currentCameraFOW;
        // 1/1 * 45 
        Debug.Log("FOW: " + Camera.main.fieldOfView);

        if (Input.GetKey("space"))
        {
            if (rb.velocity.z <= accVelo.z)
            {
                Debug.Log("Space");
                currentVelo.z = Time.deltaTime * playerAcceleration;
                rb.velocity += currentVelo;
                
                if (transform.localScale.x >= minScale) //Scaling object by speed
                {
                    
                    transform.localScale -= Time.deltaTime * scale;
                }
                

            }
            
            
        }
        if (!Input.GetKey("space"))
        { //If there's no space pushed


            if (rb.velocity.z > velo.z) //If there's velocity higher than start velocity
            {
                Debug.Log("current velo is bigger than default speed");
                currentVelo.z = -1 * Time.deltaTime * playerAcceleration;
                rb.velocity += currentVelo;

                if (transform.localScale.x <= defaultPlayerWidth) //Scaling object by speed
                {
                    
                    transform.localScale += Time.deltaTime * scale;
                }
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
