using UnityEngine;
using System.Collections;

public abstract class Apparel : Equippable
{
	public int baseDefense;
	public int heatDefense;
	public int coldDefense;

	public enum ArmorType { Unarmored = 0, Light = 1, Medium = 2, Heavy = 3 };
	public ArmorType armorType;
	public enum Collection
	{
		None = 0
	};
	public Collection collection;

	//CHANGED: this value is subject to a lot of change
	public static int maxArmorRating = 2 * 20 * 20 * 20;
	public int armorRating;

	public void CalculateArmorRating()
	{
		armorRating = Mathf.FloorToInt(durability * baseDefense * heatDefense * coldDefense);
	}

	public sealed override void CalculateValue()
	{
		value = Mathf.FloorToInt(Mathf.Pow(1 + (armorRating/maxArmorRating), 10));
	}
}
