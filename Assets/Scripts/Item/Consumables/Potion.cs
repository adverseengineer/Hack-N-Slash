using UnityEngine;
using System.Collections;

[AddComponentMenu("Items/Consumables/Potion")]
public sealed class Potion : Consumable
{
	public StatusEffect statusEffect1;
	public StatusEffect statusEffect2;
	public StatusEffect statusEffect3;

	public sealed override int CalculateValue()
	{
		//TODO: fix this formula
		value = 0;
		return value;
	}
}
