using UnityEngine;
using System.Collections;

[AddComponentMenu("Item/Weapons/Spellbook")]
public class Spellbook : Weapon
{
	public enum Collection
	{
		Novice = 0,
		Apprentice = 1,
		Journeyman = 2,
		Expert = 3,
		Master = 4
	};
	public enum Element
	{
		 Fire = 0,
		 Ice = 1
	};

	public Collection collection;
	public Element element;
	public sealed override int CalculateValue()
	{
		//TODO: write item value for Spellbook
		return 0;
	}
}
