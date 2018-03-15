using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Items/Apparel/Legs", fileName = "New Legs")]
public sealed class Legs : Apparel
{
	void OnValidate()
	{
		CalculateValue();
	}
}
