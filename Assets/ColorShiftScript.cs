using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorShiftScript : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		//float r = 0, g = 0, b = 0;
		//valToRGB(450.0f,ref r,ref g, ref b);
		//Debug.Log("Red" + r + "Green" + g + "Blue" + b);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
    /* public void valToRGB(float val0To1, ref float r, ref float g, ref float b)
    {
        //actual visible spectrum is 375 to 725 but outside of 400-700 things become too dark
        wavelengthToRGB(val0To1 * (700.0f - 400.0f) + 400.0f, ref r, ref g, ref b);
    }

    /**
    * Convert a wavelength in the visible light spectrum to a RGB color value that is suitable to be displayed on a
    * monitor
    *
    * @param wavelength wavelength in nm
    * @return RGB color encoded in int. each color is represented with 8 bits and has a layout of
    * 00000000RRRRRRRRGGGGGGGGBBBBBBBB where MSB is at the leftmost
    */
   /* private void wavelengthToRGB(float wavelength, ref float r, ref float g, ref float b) 
    {
        float x = 0.0f, y = 0.0f, z = 0.0f;
        cie1931WavelengthToXYZFit(wavelength, ref x, ref y, ref z);
        float dr = 0.0f, dg = 0.0f, db = 0.0f;
        srgbXYZ2RGB(x, y, z, ref dr, ref dg, ref db);

        r = (float)((int)(dr * 0xFF) & 0xFF);
        g = (float)((int)(dg * 0xFF) & 0xFF);
        b = (float)((int)(db * 0xFF) & 0xFF);
    }

    /**
    * Convert XYZ to RGB in the sRGB color space
    * <p>
    * The conversion matrix and color component transfer function is taken from http://www.color.org/srgb.pdf, which
    * follows the International Electrotechnical Commission standard IEC 61966-2-1 "Multimedia systems and equipment -
    * Colour measurement and management - Part 2-1: Colour management - Default RGB colour space - sRGB"
    *
    * @param xyz XYZ values in a double array in the order of X, Y, Z. each value in the range of [0.0, 1.0]
    * @return RGB values in a double array, in the order of R, G, B. each value in the range of [0.0, 1.0]
    */
   /* private void srgbXYZ2RGB(float x, float y, float z, ref float r, ref float g, ref float b) 
	{
        float rl = 3.2406255f * x + -1.537208f  * y + -0.4986286f * z;
        float gl = -0.9689307f * x + 1.8757561f * y + 0.0415175f * z;
        float bl = 0.0557101f * x + -0.2040211f * y + 1.0569959f * z;

        r = srgbXYZ2RGBPostprocess(rl);
        g = srgbXYZ2RGBPostprocess(gl);
        b = srgbXYZ2RGBPostprocess(bl);
    }

    /**
    * helper function for {@link #srgbXYZ2RGB(double[])}
    */
   /* private float srgbXYZ2RGBPostprocess(float c) 
    {
        // clip if c is out of range
        c = c > 1 ? 1 : (c < 0 ? 0 : c);

        // apply the color component transfer function
        c = c <= 0.0031308f ? c * 12.92f : 1.055f * Mathf.Pow(c, 1.0f / 2.4f) - 0.055f;

        return c;
    }

    /**
    * A multi-lobe, piecewise Gaussian fit of CIE 1931 XYZ Color Matching Functions by Wyman el al. from Nvidia. The
    * code here is adopted from the Listing 1 of the paper authored by Wyman et al.
    * <p>
    * Reference: Chris Wyman, Peter-Pike Sloan, and Peter Shirley, Simple Analytic Approximations to the CIE XYZ Color
    * Matching Functions, Journal of Computer Graphics Techniques (JCGT), vol. 2, no. 2, 1-11, 2013.
    *
    * @param wavelength wavelength in nm
    * @return XYZ in a double array in the order of X, Y, Z. each value in the range of [0.0, 1.0]
    */
   /* private void cie1931WavelengthToXYZFit(float wavelength, ref float x, ref float y, ref float z) 
   {
        float wave = wavelength;

        {
            float t1 = (wave - 442.0f) * ((wave < 442.0f) ? 0.0624f : 0.0374f);
            float t2 = (wave - 599.8f) * ((wave < 599.8f) ? 0.0264f : 0.0323f);
            float t3 = (wave - 501.1f) * ((wave < 501.1f) ? 0.0490f : 0.0382f);

            x = 0.362f * Mathf.Exp(-0.5f * t1 * t1)
                + 1.056f * Mathf.Exp(-0.5f * t2 * t2)
                - 0.065f * Mathf.Exp(-0.5f * t3 * t3);
        }

        {
            float t1 = (wave - 568.8f) * ((wave < 568.8f) ? 0.0213f : 0.0247f);
            float t2 = (wave - 530.9f) * ((wave < 530.9f) ? 0.0613f : 0.0322f);

            y = 0.821f * Mathf.Exp(-0.5f * t1 * t1)
                + 0.286f * Mathf.Exp(-0.5f * t2 * t2);
        }

        {
            float t1 = (wave - 437.0f) * ((wave < 437.0f) ? 0.0845f : 0.0278f);
            float t2 = (wave - 459.0f) * ((wave < 459.0f) ? 0.0385f : 0.0725f);

            z = 1.217f * Mathf.Exp(-0.5f * t1 * t1)
                + 0.681f * Mathf.Exp(-0.5f * t2 * t2);
        }
    }*/
}
