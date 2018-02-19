using UnityEngine;
using System.Collections;

[AddComponentMenu("Items/Consumables/Potion")]
public sealed class Potion : Consumable
{
	public StatusEffect statusEffect1;
	public StatusEffect statusEffect2;
	public StatusEffect statusEffect3;

	public sealed override void CalculateValue()
	{
		//TODO: fix this formula
		
	}
}
