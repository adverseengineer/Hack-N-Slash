using UnityEngine;
using System.Collections;

[AddComponentMenu("Items/Apparel/Bottom")]
public sealed class Bottom : Apparel
{
	void OnValidate()
	{
		CalculateValue();
	}
}
