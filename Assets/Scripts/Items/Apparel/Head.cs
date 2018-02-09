using UnityEngine;
using System.Collections;

[AddComponentMenu("Item/Apparel/Head")]
public sealed class Head : Apparel
{
	void OnValidate()
	{
		value = CalculateValue();
	}
}
