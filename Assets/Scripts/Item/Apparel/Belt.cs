using UnityEngine;
using System.Collections;

[AddComponentMenu("Items/Apparel/Belt")]
public class Belt : Apparel
{
	//OneHanded
	//TwoHanded
	//carryWeightLimit
	//MediumArmor
	//HeavyArmor
	//SP
	void OnValidate()
	{
		CalculateValue();
	}
}
