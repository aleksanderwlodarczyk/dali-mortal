using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDistanceCalc : MonoBehaviour {

	public Color32 colorA;
	public Color32 colorB;
	public Color32 colorC;

	private Vector3 v3ColorA;
	private Vector3 v3ColorB;
	private Vector3 v3ColorC;

	void Start () {
		v3ColorA = new Vector3(colorA.r, colorA.g, colorA.b);
		v3ColorB = new Vector3(colorB.r, colorB.g, colorB.b);
		v3ColorC = new Vector3(colorC.r, colorC.g, colorC.b);

		Debug.Log("Max Color Distance: " + Vector3.Distance(v3ColorA, v3ColorB));
		Debug.Log("Color Distance: " + Vector3.Distance(v3ColorA, v3ColorC));
	}
	

	void Update () {
		Debug.Log("Color Distance: " + Vector3.Distance(v3ColorA, v3ColorC));
	}
}
