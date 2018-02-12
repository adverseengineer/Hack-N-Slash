using UnityEngine;
using System.Collections;

[AddComponentMenu("Items/Apparel/Earrings")]
public sealed class Earrings : Apparel
{
	void OnValidate()
	{
		CalculateValue();
	}
}
