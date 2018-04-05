using System;
using System.Collections;
using UnityEngine;

public abstract class Ammo : Weapon
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
