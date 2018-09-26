using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Actors/Player")]
public sealed class Player : MonoBehaviour {

	public bool alive;
	public int currentHP;
	public int MaxHP;
	public float currentStamina;//each piece of a wheel is 0 to 1
	public float MaxStamina;//maxstamina/5-5=number of upgrades

	public int armorRating;
	
	public Head equippedHead;
	public Torso equippedTorso;
	public Legs equippedLegs;

	[Range(0,3)] public int attackBoost;
	[Range(0,3)] public int defenseBoost;
	[Range(0,3)] public int sneakBoost;
	[Range(0,3)] public int landSpeedBoost;
	[Range(0,3)] public int climbSpeedBoost;
	[Range(0,3)] public int swimSpeedUp;
	[Range(0,3)] public int heatResistanceBoost;
	[Range(0,3)] public int fireResistanceBoost;
	[Range(0,3)] public int frostResistanceBoost;
	[Range(0,3)] public int shockResistanceBoost;
	public int temporaryHearts;
	public int temporaryStaminaChunks;

	public int money;

	public List<Weapon> weaponStash = new List<Weapon>();
	public List<Shield> shieldStash = new List<Shield>();
	public List<Bow> bowStash = new List<Bow>();

	void Start()
	{
		alive = true;
	}

	//before calling equip(), always check to make sure the armor is actually in the inventory 

	void Equip(Head newHead)
	{
		//if player has other headgear equipped
		if(equippedHead != null)
		{
			UnequipHead();
		}
		equippedHead = newHead;
		armorRating += newHead.defense;
	}
	void Equip(Torso newTorso)
	{
		if (equippedTorso != null)
		{
			UnequipTorso();
		}
		equippedTorso = newTorso;
		armorRating += newTorso.defense;
	}
	void Equip(Legs newLegs)
	{
		if (equippedLegs != null)
		{
			UnequipLegs();
		}
		equippedLegs = newLegs;
		armorRating += newLegs.defense;
	}

	void Equip(Weapon weapon)
	{

	}


	void UnequipHead()
	{
		armorRating -= equippedHead.defense;
		equippedHead = null;
	}
	void UnequipTorso()
	{
		armorRating -= equippedTorso.defense;
		equippedTorso = null;
	}
	void UnequipLegs()
	{
		armorRating -= equippedLegs.defense;
		equippedLegs = null;
	}


}
