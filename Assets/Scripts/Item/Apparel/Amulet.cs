using UnityEngine;
using System.Collections;

[AddComponentMenu("Items/Apparel/Amulet")]
public sealed class Amulet : Apparel
{
	//HP
	//SP
	//MP
	//FP
	void OnValidate()
	{
		CalculateValue();
	}
}
