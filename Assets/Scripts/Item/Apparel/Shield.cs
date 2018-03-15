using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Items/Apparel/Shield", fileName = "New Shield")]
public sealed class Shield : Apparel
{
	//wooden = kite
	//bone = buckler
	//iron = heater
	//steel = tower
	//bronze = spartan

	void OnValidate()
	{
		CalculateValue();
	}
}
