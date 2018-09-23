using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotation : MonoBehaviour {

	Vector3 rotationRandom;
	public float rotationSpeed = 0.1f;
	public float minVelo = .7f;
	public float maxVelo = 1.3f;
	float velocity;
	private void Start  ()
	{
		
		 velocity = Random.Range(minVelo, maxVelo);
		rotationRandom = new Vector3(Random.Range(0, 360f), Random.Range(0, 360f), Random.Range(0, 360f));
		
	}

	// Update is called once per frame
	void Update () {
		Rigidbody rb = GetComponent<Rigidbody>();
		//transform.rotation = Quaternion.Euler(rotationRandom);
		transform.Rotate(rotationRandom * Time.deltaTime * rotationSpeed * rotationSpeed);
		rb.velocity = new Vector3(0, 0, -velocity);
	}
}
