﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Melee : Weapon
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
