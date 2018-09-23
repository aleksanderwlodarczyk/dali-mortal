using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsColiderScript : MonoBehaviour
{
    public GameObject PlayerPawn;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerExit()
    {
        if(PlayerPawn != null)
        {
            AsteroidsSpawner ASpawner = PlayerPawn.GetComponent<AsteroidsSpawner>();
            if(ASpawner != null)
            {
                ASpawner.Spawn();
                Destroy(gameObject);
            }
        }
    }
}
