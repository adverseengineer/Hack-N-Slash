using UnityEngine;
using System.Collections;

[CreateAssetMenu]
[AddComponentMenu("Items/Ingredient")]
public sealed class Ingredient : Item
{
	public static int ID;
	public int HP;

	public Boost.Effect Effect;
	
	public enum DyeColor
	{
		black = 0,
		blue = 1,
		brown = 2,
		crimson = 3,
		gray = 4,
		green = 5,
		lightBlue = 6,
		lightYellow = 7,
		navy = 8,
		orange = 9,
		peach = 10,
		purple = 11,
		red = 12,
		white = 13,
		yellow = 14
	}
	public DyeColor dyeColor;
}
