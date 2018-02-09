using UnityEngine;
using System.Collections;

[AddComponentMenu("Item/Apparel/Belt")]
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
		value = CalculateValue();
	}
}
