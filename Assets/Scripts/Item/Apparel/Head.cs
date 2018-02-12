using UnityEngine;
using System.Collections;

[AddComponentMenu("Items/Apparel/Head")]
public sealed class Head : Apparel
{
	void OnValidate()
	{
		CalculateValue();
	}
}
