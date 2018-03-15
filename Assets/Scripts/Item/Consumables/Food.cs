using UnityEngine;
using System.Collections;

[AddComponentMenu("Items/Consumables/Food")]
public sealed class Food : Consumable
{
	public sealed override void CalculateValue()
	{
		//TODO: food value formula
		value = 0;
	}
}
