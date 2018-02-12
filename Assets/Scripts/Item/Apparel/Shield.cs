using UnityEngine;
using System.Collections;

[AddComponentMenu("Items/Apparel/Shield")]
public sealed class Shield : Apparel
{
	//wooden = kite
	//bone = buckler
	//iron = heater
	//steel = tower
	//bronze = greek

	void OnValidate()
	{
		CalculateValue();
	}
}
