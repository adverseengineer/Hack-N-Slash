using UnityEngine;
using System.Collections;

[AddComponentMenu("Item/Weapons/Melee")]
public sealed class Melee : Weapon
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
	public enum WeaponType
	{
		Knuckleduster = 0,
		Dagger = 1,
		Shortsword = 2,
		Longsword = 3,
		Greatsword = 4,
		Quarterstaff = 5,
		Spear = 6,
		Mace = 7,
		Warhammer = 8,
		Battleaxe = 9
	};

	public int baseDamage;	//base
	public int slashDamage;	//blades
	public int chopDamage;	//bludgeons
	public int stabDamage;	//spears
	[Range(0,1)] public float criticalChance;
	[Range(1,2)] public float criticalMultiplier;
	public Material material;
	public WeaponType weaponType;

	public sealed override int CalculateValue()
	{
		float avg = (baseDamage + slashDamage + chopDamage + stabDamage) / 4;
		float std = (baseDamage - avg) * (baseDamage - avg) +
								(slashDamage - avg) * (slashDamage - avg) +
								(chopDamage - avg) * (chopDamage - avg) +
								(stabDamage - avg) * (stabDamage - avg);
		std = Mathf.Sqrt(std / 4);
		return Mathf.FloorToInt(priceMultiplier * durability * criticalChance * criticalMultiplier * std);
	}

	void OnValidate()
	{
		//TODO: finish writing OnValidate so that it takes into account all factors and returns true weapon statst
		value = CalculateValue();
		if(weaponType == WeaponType.Knuckleduster){
			baseDamage = 7;
			slashDamage = 1;
			chopDamage = 1;
			stabDamage = 5;
		}else if(weaponType == WeaponType.Dagger){
			baseDamage = 3;
			slashDamage = 5;
			chopDamage = 1;
			stabDamage = 7;
		}else if(weaponType == WeaponType.Shortsword){
			baseDamage = 4;
			slashDamage = 8;
			chopDamage = 4;
			stabDamage = 3;
		}else if(weaponType == WeaponType.Longsword){
			baseDamage = 6;
			slashDamage = 11;
			chopDamage = 10;
			stabDamage = 6;
		}else if(weaponType == WeaponType.Greatsword){
			baseDamage = 8;
			slashDamage = 13;
			chopDamage = 12;
			stabDamage = 3;
		}else if(weaponType == WeaponType.Quarterstaff){
			baseDamage = 7;
			slashDamage = 8;
			chopDamage = 7;
			stabDamage = 2;
		}else if(weaponType == WeaponType.Spear){
			baseDamage = 7;
			slashDamage = 8;
			chopDamage = 2;
			stabDamage = 13;
		}else if(weaponType == WeaponType.Mace){
			baseDamage = 6;
			slashDamage = 6;
			chopDamage = 12;
			stabDamage = 1;
		}else if(weaponType == WeaponType.Warhammer){
			baseDamage = 8;
			slashDamage = 11;
			chopDamage = 13;
			stabDamage = 1;
		}else if(weaponType == WeaponType.Battleaxe){
			baseDamage = 6;
			slashDamage = 8;
			chopDamage = 10;
			stabDamage = 2;
		}else{
			baseDamage = 0;
			slashDamage = 0;
			chopDamage = 0;
			stabDamage = 0;
		}
	}
}
