using UnityEngine;
using System.Collections;

[AddComponentMenu("Item/Consumables/Ingredient")]
public class Ingredient : Consumable
{
	public StatusEffect eff1;
	public StatusEffect eff2;
	public StatusEffect eff3;
	public sealed override void CalculateValue()
	{

	}
}
