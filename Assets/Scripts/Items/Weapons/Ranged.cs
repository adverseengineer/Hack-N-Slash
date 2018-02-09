using UnityEngine;
using System.Collections;

[AddComponentMenu("Item/Weapons/Ranged")]
public sealed class Ranged : Weapon
{
	public enum WeaponType
	{
		Longbow = 0,
		Crossbow = 1
	};
	
	public WeaponType weaponType;

	public sealed override int CalculateValue()
	{
		//TODO:Ranged weapon item value formula
		return 0;
	}
}
