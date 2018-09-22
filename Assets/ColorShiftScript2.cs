using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorShiftScript2 : MonoBehaviour 
{

	// Use this for initialization
	public double TestLength = 550.0f;
	float StartTime = 0.0f;
	void Start ()
	{
		StartTime = Time.time;
		//Vector3 vec = convert_wave_length_nm_to_rgb(TestLength);
		//Debug.Log("Red " + vec.x + "Green " + vec.y + "Blue " + vec.z);
	}
	
	// Update is called once per frame
	void Update () 
	{
		for(int i = 400 ; i <= 700; ++i)
		{
			convert_wave_length_nm_to_rgb(i);
			if(i == 700)
			{	float End = Time.time;
				Debug.Log(((End - StartTime) * 1920 * 1080) / 1000.0f );
				StartTime = End;
			}
		}
		
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
