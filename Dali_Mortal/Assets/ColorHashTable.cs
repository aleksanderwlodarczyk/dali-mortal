using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ColorHashTable : MonoBehaviour {

	public Hashtable colorHashtable = new Hashtable();
	public int count;

	private void Update()
	{
		count = colorHashtable.Count;
	}
	
	public void Serialize()
	{
		var binformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
		using (var fs = File.Create(Application.dataPath + "/colors.bin"))
		{
			binformatter.Serialize(fs, colorHashtable);
			fs.Close();
		}
		
	}

	public void Deserialize()
	{
		var binformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
		using (var fs = File.Open(Application.dataPath + "/colors.bin", FileMode.Open))
		{
			colorHashtable = (Hashtable) binformatter.Deserialize(fs);
			fs.Close();
		}
	}
}
