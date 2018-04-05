using UnityEngine;
using System.Collections;

public abstract class Ranged : Weapon
{
	public float effectiveRange;

	public sealed override int CalculateWeaponRating()
	{
		weaponRating = Mathf.FloorToInt(durability * criticalChance * criticalMultiplier * dam * effectiveRange);
		return weaponRating;
	}

	void OnValidate()
	{
		CalculateWeaponRating();
		CalculateValue();
	}
}
