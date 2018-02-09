using UnityEngine;
using System.Collections;

[AddComponentMenu("Item/Apparel/Bottom")]
public sealed class Bottom : Apparel
{
	void OnValidate()
	{
		value = CalculateValue();
	}
}
