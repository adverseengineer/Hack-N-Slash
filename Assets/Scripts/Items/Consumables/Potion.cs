using UnityEngine;
using System.Collections;

[AddComponentMenu("Consumables/Potion")]
public sealed class Potion : Consumable
{
	public Effect effect1;
	public Effect effect2;
	public Effect effect3;

	public sealed override void CalculateValue()
	{
		//TODO: fill in
	}
}
