using UnityEngine;
using System.Collections;

public abstract class Equippable : Item
{
	[Range(1,6)] public int tier;
	[Range(0,1f)] public float durability = 1f;
	public float priceMultiplier = 1f;
}
