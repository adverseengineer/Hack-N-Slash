using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Melee : Weapon
{
	public enum Material
	{
		Wood = 0,
		Iron = 1,
		Steel = 2,
		Bronzed = 3,
		Bone = 4,
		Silver = 5
	};

	[Range(0,20)] public int slash; //swords & axes
	[Range(0,20)] public int bash;  //bludgeons
	[Range(0,20)] public int stab;	//spears
	[Range(0,1)] public float criticalChance;
	[Range(1,2)] public float criticalMultiplier;
	public Material material;

	//CHANGED: this value is subject to a lot of change
	public static int maxWeaponRating = 2 * 20 * 20 * 20;
	public int weaponRating;

	//TODO: make slash bash and stab dependant on the tier and material
	//TODO: consider making the three damage types one Vector3 and normalizing it to rate the weapon

	public void CalculateWeaponRating()
	{
		weaponRating = Mathf.FloorToInt(durability * criticalChance * criticalMultiplier * slash * bash * stab);
	}

	public sealed override void CalculateValue()
	{
		value = Mathf.FloorToInt(Mathf.Pow(1 + (weaponRating/maxWeaponRating), 10));
	}

	void OnValidate()
	{
		CalculateWeaponRating();
		CalculateValue();
	}
}
