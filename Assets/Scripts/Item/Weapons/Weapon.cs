using UnityEngine;
using System.Collections;

public abstract class Weapon : Equippable
{
    public enum WeaponMaterial
	{
		Wood = 0,
		Iron = 1,
		Steel = 2,
		Bronzed = 3,
		Bone = 4,
		Silver = 5
	};

    public WeaponMaterial weaponMaterial;

	public int dam;
    [Range(0,1)] public float criticalChance;
	[Range(1,2)] public float criticalMultiplier;

    //TODO: this value is subject to a lot of change
	public static int maxWeaponRating = 1000;
	public int weaponRating;

    public abstract int CalculateWeaponRating();

	public sealed override int CalculateValue()
	{
		value = Mathf.FloorToInt(Mathf.Pow(1 + (weaponRating/maxWeaponRating), 10));
        return value;
	}
}
