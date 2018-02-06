using UnityEngine;
using System.Collections;

public abstract class Equippable : Item
{
	[Range(0,1)]
	public float durability = 1f;
	public float priceMultiplier;
}
