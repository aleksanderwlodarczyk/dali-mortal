using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorShiftScript2 : MonoBehaviour
{

	public Hashtable colorTable = new Hashtable();

	public int maxNumberOfColors = (int)Mathf.Pow(255, 3);
	// Use this for initialization
	public double TestLength = 550.0f;
	public int numberOfSkipedColors;
	public Color32 TestColor;
	void Start()
	{
		Vector3 VecColor = new Vector3(TestColor.r, TestColor.g, TestColor.b);  //convert_wave_length_nm_to_rgb(TestLength);

		//double Wave = ApproxColorToWave(ref VecColor);
		
		Debug.Log("Approx Wave " + ApproxColorToWave(ref VecColor));
	}

	// Update is called once per frame
	void Update()
	{
	}

	void GenerateColorDictionary()
	{
		Vector3 CurrentColor = new Vector3(numberOfSkipedColors, numberOfSkipedColors, numberOfSkipedColors);
		for (int i = 0; i < maxNumberOfColors / numberOfSkipedColors; i++)
		{
			float fi = (float)i + 1;
			Vector3[] ArrayOfVec = new Vector3[7];
			ArrayOfVec[0] = Vector3.Scale(CurrentColor, new Vector3(fi, 0.0f, 0.0f));
			ArrayOfVec[1] = Vector3.Scale(CurrentColor, new Vector3(0.0f, fi, 0.0f));
			ArrayOfVec[2] = Vector3.Scale(CurrentColor, new Vector3(0.0f, 0.0f, fi));
			ArrayOfVec[3] = Vector3.Scale(CurrentColor, new Vector3(fi, fi, 0.0f));
			ArrayOfVec[4] = Vector3.Scale(CurrentColor, new Vector3(fi, 0.0f, fi));
			ArrayOfVec[5] = Vector3.Scale(CurrentColor, new Vector3(0.0f, fi, fi));
			ArrayOfVec[6] = Vector3.Scale(CurrentColor, new Vector3(fi, fi, fi));

			for (int Index = 0; Index < 7; ++Index)
			{
				int Hash = Mathf.FloorToInt((2 * ArrayOfVec[Index].x) + (4 * ArrayOfVec[Index].y) + (8 * ArrayOfVec[Index].z));
				colorTable.Add(Hash, ApproxColorToWave(ref ArrayOfVec[Index]));
			}
		}
	}

	double ApproxColorToWave(ref Vector3 inColor)
	{
		float CurrentMin = 600000; // max enough
		double ReturnWave = 0;
		for (int Wave = 400; Wave <= 700; ++Wave)
		{
			Vector3 color = convert_wave_length_nm_to_rgb(Wave);
			float a = Mathf.Abs(inColor.x - color.x);
			float b = Mathf.Abs(inColor.y - color.y);
			float c = Mathf.Abs(inColor.z - color.z);

			float min = a + b + c;

			if (min < CurrentMin)
			{
				ReturnWave = Wave;
				CurrentMin = min;
			}
		}
		return ReturnWave;
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
