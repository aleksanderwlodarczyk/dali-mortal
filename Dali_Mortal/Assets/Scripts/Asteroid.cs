using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	private bool nearMissPossible;

	void Start () {
		nearMissPossible = false;
	}


	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			nearMissPossible = true;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			nearMissPossible = false;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player" && nearMissPossible)
		{
			// near miss done, add points, show text or something
			Debug.Log("near miss!");
		}
	}
}
