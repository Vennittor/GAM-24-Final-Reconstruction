using UnityEngine;
using System.Collections;

namespace HelperFunctions
{
	public static class HelperFunctions 
	{
		public static bool Approximate(this Vector3 currentVector, float closeToX, float closeToY, float closeToZ)
		{
			if (Mathf.Abs (currentVector.x) <= closeToX && Mathf.Abs (currentVector.y) <= closeToY && Mathf.Abs (currentVector.z) <= closeToZ)
				return true;
			else
				return false;
		}
		public static bool Approximate(this Vector3 currentVector, float closeToX)
		{
			if (Mathf.Abs (currentVector.x) <= Mathf.Abs(closeToX))
				return true;
			else
				return false;
		}
	}
}