using UnityEngine;
using System.Collections;

[CreateAssetMenu]
[AddComponentMenu("Items/Consumables/Ingredient")]
public sealed class Ingredient : Consumable
{
	[Range(0,1f)] public float rarity;
	public StatusEffect.Effect effect1;
	public StatusEffect.Effect effect2;
	public StatusEffect.Effect effect3;

	public sealed override int CalculateValue()
	{
		//TODO: write item value formula for Ingredient
		value = Mathf.FloorToInt(50 - 50 * rarity);
		return value;
	}

	void OnValidate()
	{
		CalculateValue();
	}
}
