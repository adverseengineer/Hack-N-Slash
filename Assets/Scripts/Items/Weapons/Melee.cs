using UnityEngine;
using System.Collections;

[AddComponentMenu("Item/Weapons/Melee")]
public sealed class Melee : Weapon
{
	//TODO:organize all this BULLSHIT
	public int baseDamage;//base
	public int slashDamage;//blades
	public int chopDamage;//bludgeons
	public int stabDamage;//spears
	[Range(0,1)]
	public float criticalChance;
	[Range(1,2)]
	public float criticalMultiplier;
	public float attackSpeed;
	public enum Collection{ Iron = 0, Steel = 1, Bronzed = 2, Bone = 3, Silver = 4 };
	public Collection collection;
	//iron is basic, well balanced material 										(medium weight, medium damage, medium durability)
	//steel is heavier than iron, but holds an edge better 			(medium weight, high damage,   medium durability)
	//bronzed does less damage, but can take a beating 					(high weigh,    low damage, 	 high durability)
	//bone really tears em up, but it breaks more easily 				(light weight		high damage,   low durability)
	public enum WeaponType { Dagger = 0, Shortsword = 1, Longsword = 2, Greatsword = 3, Spear = 4, Mace = 5, Hammer = 6, Waraxe = 7, Battleaxe = 8 };
	public WeaponType weaponType;

	public sealed override void CalculateValue()
	{
		float avg = (baseDamage + slashDamage + chopDamage + stabDamage) / 4;
		float std = (baseDamage - avg) * (baseDamage - avg) +
								(slashDamage - avg) * (slashDamage - avg) +
								(chopDamage - avg) * (chopDamage - avg) +
								(stabDamage - avg) * (stabDamage - avg);
		std = Mathf.Sqrt(std / 4);
		value = (int)(priceMultiplier * Mathf.Max(weight, attackSpeed) * durability * criticalChance * criticalMultiplier * std);
	}

	void OnValidate()
	{
		CalculateValue();
		switch(weaponType)
		{
		case WeaponType.Dagger:
			baseDamage = 3;
			slashDamage = 5;
			chopDamage = 1;
			stabDamage = 7;
			break;
		case WeaponType.Shortsword:
			baseDamage = 4;
			slashDamage = 8;
			chopDamage = 4;
			stabDamage = 3;
			break;
		case WeaponType.Longsword:
			baseDamage = 6;
			slashDamage = 11;
			chopDamage = 10;
			stabDamage = 6;
			break;
		case WeaponType.Greatsword:
			baseDamage = 8;
			slashDamage = 13;
			chopDamage = 12;
			stabDamage = 3;
			break;
		case WeaponType.Spear:
			baseDamage = 7;
			slashDamage = 2;
			chopDamage = 2;
			stabDamage = 13;
			break;
		case WeaponType.Mace:
			baseDamage = 6;
			slashDamage = 6;
			chopDamage = 12;
			stabDamage = 1;
			break;
		case WeaponType.Hammer:
			baseDamage = 8;
			slashDamage = 11;
			chopDamage = 13;
			stabDamage = 1;
			break;
		case WeaponType.Battleaxe:
			baseDamage = 6;
			slashDamage = 8;
			chopDamage = 10;
			stabDamage = 2;
			break;
		default:
			baseDamage = -1;
			slashDamage = -1;
			chopDamage = -1;
			stabDamage = -1;
			break;
		}
	}
}
