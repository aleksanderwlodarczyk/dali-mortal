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
        LastPos = transform.position;
        rb = GetComponent<Rigidbody>();
        currentVelocity = defaultSpeed;
        scale = new Vector3(0.5f, 0.5f, -1f);
        currentCameraFOW = defaultCameraFOW;
    }


	// Update is called once per frame
	void Update () {

        rotatePlayerWhileTurning();

        currentCameraFOW = 2.33f * currentVelocity + 33.3f;

        Camera.main.fieldOfView = currentCameraFOW;

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


        LastPos = transform.position;

    }

    void changeLength()
    {
        rb = GetComponent<Rigidbody>();

		currentVelocity = rb.velocity.z;

    }
    Vector3 LastPos;
    void rotatePlayerWhileTurning()
    {
        Debug.Log("rotatePlayerWhileTurning()");
        Quaternion rotationL = Quaternion.Euler(0, 0, 30f);
        Quaternion rotationR = Quaternion.Euler(0, 0, -30f);
        Quaternion rotationZero = Quaternion.Euler(0, 0, 0);
        Debug.Log(LastPos.x);
        if (transform.position.x<LastPos.x)
        {
           transform.rotation = Quaternion.Slerp(transform.rotation,rotationL, Time.deltaTime);
        }
        else if(transform.position.x > LastPos.x)
        {
            
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationR, Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationZero, Time.deltaTime);
        }

    }


}
