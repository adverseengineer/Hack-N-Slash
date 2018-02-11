using UnityEngine;
using System.Collections;

[AddComponentMenu("Item/Apparel/Shield")]
public sealed class Shield : Apparel
{
	//wooden = kite
	//bone = buckler
	//iron = heater
	//steel = tower
	//bronze = greek

	void OnValidate()
	{
		value = CalculateValue();
	}
}
