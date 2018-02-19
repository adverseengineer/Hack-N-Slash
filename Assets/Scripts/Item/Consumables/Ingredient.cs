using UnityEngine;
using System.Collections;

[CreateAssetMenu]
[AddComponentMenu("Items/Consumables/Ingredient")]
public class Ingredient : Consumable
{
	[Range(0,1f)] public float rarity;
	public StatusEffect.Stat effect1;
	public StatusEffect.Stat effect2;
	public StatusEffect.Stat effect3;

	public sealed override void CalculateValue()
	{
		//TODO: write item value formula for Ingredient
		value = Mathf.FloorToInt(50 - 50 * rarity);
	}

	public static Ingredient GenerateIngredient()
	{
		//TODO: Procedurally generate ingredients
			return null;
	}

	void OnValidate()
	{
		CalculateValue();
	}
}
