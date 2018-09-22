using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class AsteroidsSpawner : MonoBehaviour {

	public List<GameObject> segments = new List<GameObject>();
	public Transform placeToSpawn;
	public float maxXdelta;
	public float maxYdelta;

	private  Vector3 startLocalPosition;
	void Start () {
		startLocalPosition = gameObject.transform.localPosition;

	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.K))
		{
			Debug.Log("Spawning");
			if (!placeToSpawn)
			{
				placeToSpawn = gameObject.transform;
			}
			Spawn();
		}
	}

	public void Spawn()
	{
		RandomPosition();
		GameObject toSpawn = RandomListItem<GameObject>(segments);
		GameObject spawned = Instantiate(toSpawn, placeToSpawn.position, placeToSpawn.rotation);
	}

	public T RandomListItem<T>(List<T> list)
	{
		int index = Random.Range(0, list.Count);
		return list[index];
	}

	public void RandomPosition()
	{
		int xMultiplier;
		int yMultiplier;
		gameObject.transform.localPosition = startLocalPosition;
		int random;
		random = Random.Range(0, 100);
		xMultiplier = (random > 50) ? 1 : -1;
		random = Random.Range(0, 100);
		yMultiplier = (random > 50) ? 1 : -1;

		float xChange = Random.Range(0, maxXdelta);
		float yChange = Random.Range(0, maxYdelta);

		xChange *= xMultiplier;
		yChange *= yMultiplier;

		gameObject.transform.localPosition += new Vector3(xChange, yChange);
	}
}
