using UnityEngine;
using System.Collections;

[AddComponentMenu("Items/Apparel/Top")]
public sealed class Top : Apparel
{
	void OnValidate()
	{
		CalculateValue();
	}
}
