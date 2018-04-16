using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Functions
{
	public static float ClampAngle(float angle, float min, float max)
  	{
  		if (angle < -360F)
    		angle += 360F;
  		if (angle > 360F)
    		angle -= 360F;
  		return Mathf.Clamp(angle, min, max);
  	}

	public static float Average(List<float> arg)
	{
		float result = 0f;
		foreach(float f in arg)
			result += f;
		return result / arg.Count;
	}

	public static float Stddev(List<float> arg)
	{
		float avg = Average(arg);
		float sum = 0f;
		foreach(float f in arg)
		{
			sum += (f - avg) * (f - avg);
		}
		return Mathf.Sqrt(sum/arg.Count);
	}

	public static void SortAlphabetically(List<string> arg)
	{
		//TODO: fill out this algorithm
	}
}
