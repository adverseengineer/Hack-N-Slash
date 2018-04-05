using UnityEngine;
using System.Collections;

public abstract class Artifice : Weapon
{
	public sealed override int CalculateWeaponRating()
	{
		weaponRating = Mathf.FloorToInt(durability * criticalChance * criticalMultiplier * dam);
		return weaponRating;
	}

	void OnValidate()
	{
		CalculateWeaponRating();
		CalculateValue();
	}
}
