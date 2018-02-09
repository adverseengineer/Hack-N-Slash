using UnityEngine;
using System.Collections;

[AddComponentMenu("Item/Apparel/Earrings")]
public sealed class Earrings : Apparel
{
	void OnValidate()
	{
		value = CalculateValue();
	}
}
