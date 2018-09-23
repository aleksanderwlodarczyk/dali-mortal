using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    // Use this for initialization

    int MaxnumberOfAsteroids;
    public GameObject[] Asteroids;
	void Start ()
    {
        for (int Index = 0; Index < Asteroids.Length; ++Index)
        {
   //         Instantiate(Asteroids[Index], new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	    	
	}
}
