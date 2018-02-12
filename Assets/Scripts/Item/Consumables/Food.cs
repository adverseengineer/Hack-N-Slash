using UnityEngine;
using System.Collections;

[AddComponentMenu("Items/Consumables/Food")]
public sealed class Food : Consumable
{
	public StatusEffect eff1;
	public StatusEffect eff2;
	public StatusEffect eff3;

	public sealed override void CalculateValue()
	{
		//TODO: food value formula
		value = 0;
	}
}
