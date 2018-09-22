using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHashTable : MonoBehaviour {

	public Hashtable colorHashtable = new Hashtable();
	public int count;

	private void Update()
	{
		count = colorHashtable.Count;
	}
}
