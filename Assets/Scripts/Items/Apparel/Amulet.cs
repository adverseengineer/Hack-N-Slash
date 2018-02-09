using UnityEngine;
using System.Collections;

[AddComponentMenu("Item/Apparel/Amulet")]
public sealed class Amulet : Apparel
{
	//HP
	//SP
	//MP
	//FP
	void OnValidate()
	{
		value = CalculateValue();
	}
}
