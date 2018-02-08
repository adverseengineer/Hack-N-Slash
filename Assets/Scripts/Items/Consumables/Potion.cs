using UnityEngine;
using System.Collections;

[AddComponentMenu("Item/Consumables/Potion")]
public sealed class Potion : Consumable
{
	public StatusEffect effect1;
	public StatusEffect effect2;
	public StatusEffect effect3;

	public sealed override void CalculateValue()
	{
		//TODO: fill in
	}
}
