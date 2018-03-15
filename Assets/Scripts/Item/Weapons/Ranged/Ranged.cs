using UnityEngine;
using System.Collections;

public abstract class Ranged : Weapon
{
	public float effectiveRange;

	public sealed override void CalculateValue()
	{
		//TODO:Ranged weapon item value formula
		value = 0;
	}
}
