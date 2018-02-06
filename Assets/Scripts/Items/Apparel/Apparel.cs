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
		None = 0,
		CarodonianRoyalGuard = 1,
		CommonerClothes1 = 2,
		CommonerClothes2 = 3,
		CommonerClothes3 = 4,
		TribalClothes1 = 5,
		TribalClothes2 = 6,
		TribalClothes3 = 7
	};
	public Collection collection;

	public sealed override void CalculateValue()
	{
		float avg = (baseDefense + heatDefense + coldDefense) / 3;
		float std = (baseDefense - avg) * (baseDefense - avg) +
								(heatDefense - avg) * (heatDefense - avg) +
								(coldDefense - avg) * (coldDefense - avg);
		std = Mathf.Sqrt(std / 3);
		value = (int)(priceMultiplier * durability * std);
	}
}
