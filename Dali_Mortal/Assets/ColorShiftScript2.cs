using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorShiftScript2 : MonoBehaviour
{

	public Hashtable colorTable = new Hashtable();
	public Dictionary<double, Vector3> colorDictionary = new Dictionary<double, Vector3>();

	public int maxNumberOfColors = (int)Mathf.Pow(255, 3);
	// Use this for initialization
	public double TestLength = 550.0f;
	public int numberOfSkipedColors;
	public Color32 TestColor;

	public Color32 color1;
	public Color32 color2;
	public PlayerSpeed player;
	public double sourceWave;
	public int tries = 0;

	//public Material testMat;
	public ColorHashTable colorHashTablePrefab;
	[Range(0, 3)]
	public float testVelocity = 0f;
	public List<Material> allMaterials = new List<Material>();
	public List<double> matsWavelength = new List<double>();
	public Dictionary<Material, Color> startColors = new Dictionary<Material, Color>();

	void Start()
	{
		Vector3 VecColor = new Vector3(TestColor.r, TestColor.g, TestColor.b);
		
		if (colorHashTablePrefab)
		{
			//saving
			//GenerateColorDictionary();
			//colorHashTablePrefab.colorHashtable = colorTable;
			//colorHashTablePrefab.Serialize();

			//loading
			colorHashTablePrefab.Deserialize();
			colorTable = colorHashTablePrefab.colorHashtable;

			for (int i = 380; i <= 780; i++)
			{
				colorDictionary.Add((double)i, convert_wave_length_nm_to_rgb((double)i));
			}
		}

		foreach(Material mat in allMaterials)
		{
			startColors.Add(mat, mat.color);
			Vector3 matColor = new Vector3(mat.color.r, mat.color.g, mat.color.b);
			matsWavelength.Add(ApproxColorToWave(ref matColor));
		}

	}

	// Update is called once per frame
	void Update()
	{
		SetMaterialsColors();
	}

	public void SetMaterialsColors()
	{
        
		foreach(Material mat in allMaterials)
		{
			//mat.color
			
			Vector3 colorVec = new Vector3(startColors[mat].r, startColors[mat].g, startColors[mat].b);
			sourceWave = ApproxColorToWave(ref colorVec);
			double observeWave;

            Vector3 colorDelta = colorVec - colorDictionary[sourceWave];

			if (testVelocity > 0)
			{
				observeWave = sourceWave * (1d / (1 + (testVelocity - 1) / 3d));
				observeWave = Mathf.CeilToInt((float)observeWave);



				if (observeWave < 380) observeWave += 400;
				else if (observeWave > 780) observeWave -= 400;

				try
				{
					Vector3 newColor = colorDictionary[observeWave];
					newColor += colorDelta;
					Color dopplerColor = new Color(newColor.x / 255f, newColor.y / 255f, newColor.z * 255f, mat.color.a);
					mat.color = dopplerColor;
				}
				catch (KeyNotFoundException e)
				{

				}
			}
			//string colorString = "";

			//if (colorDictionary.ContainsKey(observeWave))
			//{
			//	colorString = colorDictionary[observeWave];

			//	float r = 0;
			//	float g = 0;
			//	float b = 0;
			//	if (colorString != "")
			//	{
			//		r = float.Parse(colorString.Substring(0, 3));
			//		g = float.Parse(colorString.Substring(2, 3));
			//		b = float.Parse(colorString.Substring(5, 3));
			//	}


				//Color newColor = new Color(r / 255f, g / 255f, b / 255f, mat.color.a);
				//mat.color = newColor;
			//}

		}
	}

	//private void OnRenderImage(RenderTexture source, RenderTexture destination)
	//{
	//	//Texture TempTexture = source;
	//	//source.colorBuffer
	//	//TempTexture.
	//	//testMat.SetFloat("playerSpeed", player.currentVelocity);
	//	//Graphics.Blit(source, destination, testMat);
	//	//testMat.SetMatrix(Array"ColorHashTable", );
	//	List<Vector4> list = new List<Vector4>();
	//	ConvertHashtableToVectorArray(ref list);

	//	//Shader.SetGlobalVectorArray(1, list);

	//	//testMat.shader
	//	//Graphics.Blit(source, destination, testMat);//delete it later
	//}



	void ConvertHashtableToVectorArray(ref List<Vector4> list)
	{
		foreach (DictionaryEntry p in colorTable)
		{
			string value = p.Value.ToString();
			string hashkey = p.Key.ToString();
			float r = float.Parse(hashkey.Substring(0, 3));
			float g = float.Parse(hashkey.Substring(2, 3));
			float b = float.Parse(hashkey.Substring(5, 3));
			float floatWaveLength = float.Parse(value);
			list.Add(new Vector4(r, g, b, floatWaveLength));
		}
	}
	void GenerateColorDictionary()
	{
		Vector3 CurrentColor = new Vector3(1.0f, 1.0f, 1.0f);
		Vector3[] ArrayOfVec = new Vector3[7];
		int Index1 = 1;
		int Index2 = 1;
		int Index3 = 1;

		float r = 0;
		float g = 0;
		float b = 0;

		for (; Index1 <= 255; Index1 +=numberOfSkipedColors)
		{
			r = Index1;
			g = 0;
			Index2 = 0;
			for (; Index2 <= 255; Index2 += numberOfSkipedColors)
			{
				g = Index2;
				b = 0;
				Index3 = 0;
				for (; Index3 <= 255; Index3 += numberOfSkipedColors)
				{
					b = Index3;
					Vector3 NewColor = new Vector3(r, g, b);

					string Hash = String.Format("{0}{1}{2}", X((int)NewColor.x) + NewColor.x, X((int)NewColor.y) + NewColor.y, X((int)NewColor.z) + NewColor.z);
					//Vector3 Hash = NewColor;
					++tries;
					if (!colorTable.ContainsKey(Hash))
					{
						colorTable.Add(Hash, ApproxColorToWave(ref NewColor));
					}
				}
			}
		}
	}

	string X (int Number)
	{
		if (Number / 100 > 0)
		{
			return "";
		}
		else if (Number / 10 > 10)
		{
			return "0";
		}
		else
		{
			return "00";
		}
	}

	public double ApproxColorToWave(ref Vector3 inColor)
	{
		double CurrentMin = 600000d; // max enough
		double ReturnWave = 0d; double min = 0d;
		for (int Wave = 380; Wave <= 780; ++Wave)
		{
			Vector3 color = convert_wave_length_nm_to_rgb(Wave);
			//float a = Mathf.Abs(inColor.x - color.x);
			//float b = Mathf.Abs(inColor.y - color.y);
			//float c = Mathf.Abs(inColor.z - color.z);

			int[] labIn = rgb2lab((int)inColor.x, (int)inColor.y, (int)inColor.z);
			int[] labMap = rgb2lab((int)color.x, (int)color.y, (int)color.z);

			int inColorLabInt = labIn[0] * labIn[1] * labIn[2];
			int mapColorLabInt = labMap[0] * labMap[1] * labMap[2];

			min = GetColorDifference(labIn, labMap);

			if (min < CurrentMin)
			{
				ReturnWave = Wave;
				CurrentMin = min;
			}
		}
		Debug.Log(min);
		int lol;
		return ReturnWave;
	}

	public int[] rgb2lab(int R, int G, int B)
	{
		float r, g, b, X, Y, Z, fx, fy, fz, xr, yr, zr;
		float Ls, As, bs;
		float eps = 216f / 24389f;
		float k = 24389f / 27f;

		float Xr = 0.964221f;  // reference white D50
		float Yr = 1.0f;
		float Zr = 0.825211f;

		// RGB to XYZ
		r = R / 255f; //R 0..1
		g = G / 255f; //G 0..1
		b = B / 255f; //B 0..1

		// assuming sRGB (D65)
		if (r <= 0.04045)
			r = r / 12;
		else
			r = (float)System.Math.Pow((r + 0.055) / 1.055, 2.4);

		if (g <= 0.04045)
			g = g / 12;
		else
			g = (float)System.Math.Pow((g + 0.055) / 1.055, 2.4);

		if (b <= 0.04045)
			b = b / 12;
		else
			b = (float)System.Math.Pow((b + 0.055) / 1.055, 2.4);


		X = 0.436052025f * r + 0.385081593f * g + 0.143087414f * b;
		Y = 0.222491598f * r + 0.71688606f * g + 0.060621486f * b;
		Z = 0.013929122f * r + 0.097097002f * g + 0.71418547f * b;

		// XYZ to Lab
		xr = X / Xr;
		yr = Y / Yr;
		zr = Z / Zr;

		if (xr > eps)
			fx = (float)System.Math.Pow(xr, 1 / 3d);
		else
			fx = (float)((k * xr + 16d) / 116d);

		if (yr > eps)
			fy = (float)System.Math.Pow(yr, 1 / 3d);
		else
			fy = (float)((k * yr + 16d) / 116d);

		if (zr > eps)
			fz = (float)System.Math.Pow(zr, 1 / 3d);
		else
			fz = (float)((k * zr + 16d) / 116);

		Ls = (116 * fy) - 16;

		As = 500 * (fx - fy);
		bs = 200 * (fy - fz);

		int[] lab = new int[3];
		lab[0] = (int)(/*2.55 **/ Ls + .5);
		lab[1] = (int)(As + .5);
		lab[2] = (int)(bs + .5);
		return lab;
	}

	public double GetColorDifference(int[] lab1, int[] lab2)
	{
		//int r1, g1, b1, r2, g2, b2;
		//r1 = (a >> 16) & 0xFF;
		//g1 = (a >> 8) & 0xFF;
		//b1 = a & 0xFF;
		//r2 = (b >> 16) & 0xFF;
		//g2 = (b >> 8) & 0xFF;
		//b2 = b & 0xFF;
		//int[] lab1 = rgb2lab(r1, g1, b1);
		//int[] lab2 = rgb2lab(r2, g2, b2);
		return System.Math.Sqrt(System.Math.Pow(lab2[0] - lab1[0], 2) + System.Math.Pow(lab2[1] - lab1[1], 2) + System.Math.Pow(lab2[2] - lab1[2], 2));
	}
	Vector3 convert_wave_length_nm_to_rgb(double wave_length_nm)
{
   // Credits: Dan Bruton http://www.physics.sfasu.edu/astro/color.html
   double red   = 0.0;
   double green = 0.0;
   double blue  = 0.0;

   if ((380.0 <= wave_length_nm) && (wave_length_nm <= 439.0))
   {
      red   = -(wave_length_nm - 440.0) / (440.0 - 380.0);
      green = 0.0;
      blue  = 1.0;
   }
   else if ((440.0 <= wave_length_nm) && (wave_length_nm <= 489.0))
   {
      red   = 0.0;
      green = (wave_length_nm - 440.0) / (490.0 - 440.0);
      blue  = 1.0;
   }
   else if ((490.0 <= wave_length_nm) && (wave_length_nm <= 509.0))
   {
      red   = 0.0;
      green = 1.0;
      blue  = -(wave_length_nm - 510.0) / (510.0 - 490.0);
   }
   else if ((510.0 <= wave_length_nm) && (wave_length_nm <= 579.0))
   {
      red   = (wave_length_nm - 510.0) / (580.0 - 510.0);
      green = 1.0;
      blue  = 0.0;
   }
   else if ((580.0 <= wave_length_nm) && (wave_length_nm <= 644.0))
   {
      red   = 1.0;
      green = -(wave_length_nm - 645.0) / (645.0 - 580.0);
      blue  = 0.0;
   }
   else if ((645.0 <= wave_length_nm) && (wave_length_nm <= 780.0))
   {
      red   = 1.0;
      green = 0.0;
      blue  = 0.0;
   }

   double factor = 0.0;

   if ((380.0 <= wave_length_nm) && (wave_length_nm <= 419.0))
      factor = 0.3 + 0.7 * (wave_length_nm - 380.0) / (420.0 - 380.0);
   else if ((420.0 <= wave_length_nm) && (wave_length_nm <= 700.0))
      factor = 1.0;
   else if ((701.0 <= wave_length_nm) && (wave_length_nm <= 780.0))
      factor = 0.3 + 0.7 * (780.0 - wave_length_nm) / (780.0 - 700.0);
   else
      factor = 0.0;

   Vector3 result;

   const double gamma         =   0.8;
   const double intensity_max = 255.0;

   result.x  = (byte)((red   == 0.0) ? red   : System.Math.Floor((intensity_max * System.Math.Pow(red   * factor, gamma)) + 0.5));
   result.y = (byte)((green == 0.0) ? green : System.Math.Floor((intensity_max * System.Math.Pow(green * factor, gamma)) + 0.5));
   result.z  = (byte)((blue  == 0.0) ? blue  : System.Math.Floor((intensity_max * System.Math.Pow(blue  * factor, gamma)) + 0.5));

   return result;
}
};
