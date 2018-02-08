using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class Actor : MonoBehaviour {

	public enum Sex { Male = 0, Female = 1 };
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

	public String Name;
	public Sex sex;
	public Race race;
	public int level;
	public int gold;
	public int carryWeightLimit;
	public List<Item> inventory = new List<Item>();
	public List<StatusEffect> activeEffects = new List<StatusEffect>();

	[Space(6)]
	public int maxHP;
	public int currentHP;

	[Space(6)]
	public int maxSP;
	public int currentSP;

	[Space(6)]
	public int maxMP;
	public int currentMP;

	[Space(6)]
	public int maxFP;
	public int currentFP;

	[Space(18)]

	public int ATK; //atk - your unarmed attack power. increase by equiping a weapon
	public int DEF; //def - your unarmored defense. increase by equiping armor or a shield
	public int SPD; //spd - who hits first in a fight. higher speed means less chance of a counterattack
	public int LCK; //lck - small actions like bribing, lockpicking and sneaking increase by keeping good karma

	[Space(18)]

	public int STR; //STR - effectiveness of large melee weapons
	public int DEX;	//DEX - effectiveness of small melee weapons and ranged weapons
	public int WIS; //WIS - effectiveness of spellbooks and staves
	public int CHA; //CHA - effectiveness of all pacifist actions

	[Space(18)]

	[Range(0,1f)] public float heatResistance = 0.0f;
	[Range(0,1f)] public float coldResistance = 0.0f;
	[Range(0,1f)] public float evasionRate = 		0.05f;
	[Range(0,1f)] public float criticalRate = 	0.05f;
	[Range(1,2f)] public float criticalMult = 	1.0f;

	[Space(18)]

	[Range(0,100)] public int Arcane;
	[Range(0,100)] public int Alchemy;
	[Range(0,100)] public int Survival;
	[Range(0,100)] public int Repair;
	[Range(0,100)] public int Security;
	[Range(0,100)] public int Speech;
	[Range(0,100)] public int Barter;
	[Range(0,100)] public int Sneak;
	[Range(0,100)] public int LightArmor;
	[Range(0,100)] public int MediumArmor;
	[Range(0,100)] public int HeavyArmor;
	[Range(0,100)] public int Block;
	[Range(0,100)] public int OneHanded;
	[Range(0,100)] public int TwoHanded;
	[Range(0,100)] public int Marksman;

	[Space(18)]

	public Weapon 		EquippedWeapon;

	public Head 			EquippedHead;
	public Top 				EquippedTop;
	public Bottom 		EquippedBottom;
	public Shield 		EquippedShield;

	public Ring 			EquippedRing;
	public Earrings 	EquippedEarrings;
	public Amulet 		EquippedAmulet;
	public Belt 			EquippedBelt;

	[Space(18)]

	[Range(0,1f)] public float HeadCondition = 1f;			//concussion
	[Range(0,1f)] public float TorsoCondition = 1f;			//broken ribs
	[Range(0,1f)] public float LeftArmCondition = 1f;		//trauma
	[Range(0,1f)] public float RightArmCondition = 1f;	//trauma
	[Range(0,1f)] public float LeftLegCondition = 1f;		//trauma
	[Range(0,1f)] public float RightLegCondition = 1f;	//trauma


	void OnValidate()
	{
		if(currentHP > maxHP) currentHP = maxHP;
		if(currentSP > maxSP) currentSP = maxSP;
		if(currentMP > maxMP) currentMP = maxMP;
		if(currentFP > maxFP) currentFP = maxFP;
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
		switch(race)
		{
		case Race.debug:
			//DEBUG
			break;
		case Race.human1:
			//carodonian
			STR += 10;
			WIS += 10;
			CHA += 10;
			maxSP += 10;
			currentSP += 10;
			heatResistance += 0.1f;
			break;
		case Race.human2:
			//ericson
			STR += 10;
			WIS += 10;
			CHA += 10;
			maxSP += 10;
			currentSP += 10;
			coldResistance += 0.1f;
			break;
		case Race.human3:
			//Da'jonte
			DEX += 10;
			STR += 10;
			CHA -= 10;
			maxFP += 20;
			currentFP += 20;
			break;
		case Race.elf:
			//elf
			WIS += 10;
			DEF -= 10;
			CHA += 10;
			maxMP += 10;
			currentMP += 10;
			break;
		case Race.dwarf:
			//dwarf
			LCK -= 10;
			maxHP += 20;
			currentHP += 20;
			maxSP += 10;
			currentSP += 10;
			evasionRate += 0.1f;
			break;
		case Race.halfling:
			//halfling
			this.DEX += 30;
			this.SPD += 10;
			this.LCK += 10;
			this.STR -= 30;
			break;
		case Race.tiefling:
			//tiefling
			CHA -= 20;
			LCK += 10;
			maxFP += 10;
			currentFP += 10;
			evasionRate += 0.1f;
			break;
		case Race.orc:
			//orc
			STR += 30;
			CHA -= 10;
			ATK += 10;
			maxMP -= 20;
			currentMP -= 20;
			break;
		}
	}
	*/

	public abstract void UpdateStatus();

}
