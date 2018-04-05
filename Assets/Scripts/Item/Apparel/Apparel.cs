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
	public static int maxArmorRating = 1000;
	public int armorRating;

	public int CalculateArmorRating()
	{
		armorRating = Mathf.FloorToInt(durability * baseDefense * heatDefense * coldDefense);
		return armorRating;
	}

	public sealed override int CalculateValue()
	{
		//this formula compares the armor rating to the max armor rating possible in-game
		value = Mathf.FloorToInt(Mathf.Pow(1 + (armorRating/maxArmorRating), 10));
		return value;
	}
}
