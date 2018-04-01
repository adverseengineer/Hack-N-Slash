using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public abstract class Actor : MonoBehaviour
{

	public enum Sex
	{
		Male = 0,
		Female = 1
	};
	public enum Race
	{
		debug = 0,
		human1 = 1,
		human2 = 2,
		human3 = 3,
		elf1 = 4,
		elf2 = 5,
		dwarf = 6,
		halfling = 7,
		tiefling = 8,
		orc = 9
	};
	public enum Faction
	{
		none = 0,
		debugFaction1 = 1,
		debugFaction2 = 2,
		debugFaction3 = 3,
		debugFaction4 = 4
	}

	public String Name;
	public Sex sex;
	public Race race;
	public Faction faction;
	public bool alive;
	public int level;
	public int gold;
	public int currentCarryWeight;
	public int carryWeightLimit;
	public int movementSpeed;//divide by 100 in all calculations
	[HideInInspector] public bool swimming;
	[HideInInspector] public float breath;
	public int XPGainRate;//divide by 100 in all calculations
	public List<Item> inventory = new List<Item>();
	public List<StatusEffect> activeEffects = new List<StatusEffect>();

	[Space(5)]
	public int maxHP;
	public int currentHP;
	public int HPRegenRate;//measured in ppm (points per minute)

	[Space(5)]
	public int maxSP;
	public int currentSP;
	public int SPRegenRate;//measured in ppm (points per minute)

	[Space(5)]
	public int maxMP;
	public int currentMP;
	public int MPRegenRate;//measured in ppm (points per minute)

	[Space(18)]

	public int ATK; //atk - your unarmed attack power. increase by equiping a weapon
	public int DEF; //def - your unarmored defense. increase by equiping armor or a shield
	public int SPD; //spd - who hits first in a fight. higher speed means less chance of a counterattack

	[Space(18)]
	[Header("Ability Stats")]
	[Range(0,10)] public int STR; //STR - effectiveness of large melee weapons
	[Range(0,10)] public int DEX;//DEX - effectiveness of small melee weapons and ranged weapons
	[Range(0,10)] public int WIS; //WIS - effectiveness of spellbooks and staves
	[Range(0,10)] public int CHA; //CHA - effectiveness of all pacifist actions

	[Space(18)]
	[Header("Percentile Stats")]
	//these five values need to be divided by 100 when used in calculations
	[Range(0,100)] public int heatResistance = 0;
	[Range(0,100)] public int coldResistance = 0;
	[Range(0,100)] public int evasionRate = 5;
	[Range(0,100)] public int criticalRate = 5;
	[Range(100,200)] public int criticalMult = 100;

	[Space(18)]
	[Header("Skill Stats")]
	[Range(0,100)] public int Arcane;
	[Range(0,100)] public int Alchemy;
	[Range(0,100)] public int Survival;
	[Range(0,100)] public int Repair;
	[Range(0,100)] public int Security;
	[Range(0,100)] public int Speech;
	[Range(0,100)] public int Stealth;
	[Range(0,100)] public int LightArmor;
	[Range(0,100)] public int MediumArmor;
	[Range(0,100)] public int HeavyArmor;
	[Range(0,100)] public int Block;
	[Range(0,100)] public int OneHanded;
	[Range(0,100)] public int TwoHanded;
	[Range(0,100)] public int Marksman;

	[Space(18)]
	[Header("Equipment")]
	public Weapon EquippedWeaponL;
	public Weapon EquippedWeaponR;
	public Head EquippedHead;
	public Torso EquippedTorso;
	public Legs EquippedLegs;
	public Shield EquippedShield;
	public Accessory EquippedAccessory;
	private float currentNoiseLevel;

	[Space(18)]
	[Header("Condition")]
	[Range(0,1f)] public float HeadCondition = 1f;
	[Range(0,1f)] public float TorsoCondition = 1f;
	[Range(0,1f)] public float LeftArmCondition = 1f;
	[Range(0,1f)] public float RightArmCondition = 1f;
	[Range(0,1f)] public float LeftLegCondition = 1f;
	[Range(0,1f)] public float RightLegCondition = 1f;

	//increases as you get more and more tired
	//0-500 in 48 hours
	[Range(0,500)] public int fatigue;
	//0 = well rested, +20 SP, +5 to all skills, +10% XP gain
	//100 = could use a nap, <no effects>
	//300 = tired, -10% movement speed, -20% to SP, MP, and FP regen, -20 speech, -10 barter -10 security
	//500 = walking dead, -30% movement speed, -100% SP regen, <may pass out without warning>
	//500+ = if by chance you never pass out, you will die after fatigue reaches 600

	//increases the longer you go without food
	//0-500 in 72 hours
	[Range(-100,500)] public int hunger;
	//-100 = glutted, -10% movement speed
	//0 = sated, <no effects> +10% HP-SP-MP-FP regen
	//100 = a bit peckish, <no effects>
	//300 = starving, <edges of screen blur>, +10% regen to all meters
	//500 = emaciated, <die>


	//increases the longer you go without water
	//0-500 in 72 hours
	[Range(-100,500)] public int thirst;
	//-100 = bloated, -10% movement speed
	//0 = hydrated, +10 MP, +10 FP
	//100 = dry, <no effects>
	//300 = parched, -10% MP regen
	//500 = dessicated, <die>

	[Space(18)]
	[Header("Physics")]
	public float pushPowerMultiplier = 1f;
	public float weight = 100f;

	public void Die()
	{
		alive = false;
		Destroy(this, 3);
	}

	void OnValidate()
	{
		//prevent myself from accidentally overfilling a meter
		if(currentHP > maxHP) currentHP = maxHP;
		if(currentSP > maxSP) currentSP = maxSP;
		if(currentMP > maxMP) currentMP = maxMP;
		//applyRaceBonuses(race);
	}

	/*
	public void applyRaceBonuses(Race race)
	{
		//TODO: update the race bonuses to consider new features that have been added
		maxHP = currentHP = 20;
		maxSP = currentSP = maxMP = currentMP = maxFP = currentFP = 15;
		ATK = DEF = SPD = LCK = 10;
		STR = DEX = WIS = CHA = 10;
		evasionRate = criticalRate = 0.05f;
		heatResistance = coldResistance = 0f;
	}
	*/
}
