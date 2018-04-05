using UnityEngine;
using System.Collections;

[AddComponentMenu("Items/Weapons/Spell")]
public class Spell : Weapon
{
	public enum Collection
	{
		Novice = 0,
		Apprentice = 1,
		Journeyman = 2,
		Expert = 3,
		Master = 4
	};

	public enum Purpose
	{
		Enhancement = 0, //green //strengthening themselves or objects
		Transmutation = 1, //purple //changing the quality or aura of something to match something else
		Conjuration = 2, //red //creating objects from aura
		Specialization = 3, //blue //unique effect
		Manipulation = 4, //grey //controlling animate or inanimate things
		Emission = 5, //yellow //detaching aura from body
	};

	public Collection collection;
	public Purpose purpose;

	public sealed override int CalculateWeaponRating()
	{
		//TODO: finish this formula
		weaponRating = 0;
		return weaponRating;
	}
}
