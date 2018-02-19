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

	public String Name;
	public Sex sex;
	public Race race;
	public int level;
	public int gold;
	public int carryWeightLimit;
	public float movementSpeed;
	public float XPGainRate;
	public Animator animator;
	public List<Item> inventory = new List<Item>();
	public List<String> activeEffects = new List<String>();

	[Space(6)]
	public int maxHP;
	public int currentHP;
	public float HPRegenRate;

	[Space(6)]
	public int maxSP;
	public int currentSP;
	public float SPRegenRate;

	[Space(6)]
	public int maxMP;
	public int currentMP;
	public float MPRegenRate;

	[Space(18)]

	public int ATK; //atk - your unarmed attack power. increase by equiping a weapon
	public int DEF; //def - your unarmored defense. increase by equiping armor or a shield
	public int SPD; //spd - who hits first in a fight. higher speed means less chance of a counterattack
	public int LCK; //lck - small actions like bribing, lockpicking and sneaking increase by keeping good karma

	[Space(18)]

	[Range(0,10)] public int STR; //STR - effectiveness of large melee weapons
	[Range(0,10)] public int DEX;	//DEX - effectiveness of small melee weapons and ranged weapons
	[Range(0,10)] public int WIS; //WIS - effectiveness of spellbooks and staves
	[Range(0,10)] public int CHA; //CHA - effectiveness of all pacifist actions

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
	[Range(0,100)] public int Stealth;
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

	public IEnumerator ApplyStatusEffect(StatusEffect statusEffect)
	{
		//TODO: do all of the math to convert actor float values from 0-1 range to int 0-100 range so that potency can be an int in this function
		float originalValue = 0f;
		//CHANGED: implemented alchemy skill formula, ripped straight from new vegas
		//f(x)=3x/5+3
		statusEffect.potency = statusEffect.potency * 3 / 5 + 3;
		switch(statusEffect.stat)
		{
		case StatusEffect.Stat.RestoreHP:
			currentHP += Mathf.FloorToInt(statusEffect.potency);
			break;
		case StatusEffect.Stat.RestoreSP:
			currentSP += Mathf.FloorToInt(statusEffect.potency);
			break;
		case StatusEffect.Stat.RestoreMP:
			currentMP += Mathf.FloorToInt(statusEffect.potency);
			break;
		case StatusEffect.Stat.FortifyHP:
			originalValue = (float) maxHP;
			maxHP += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
			maxHP = (int) originalValue;
			break;
		case StatusEffect.Stat.FortifySP:
			originalValue = (float) maxSP;
			maxSP += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
			maxSP = (int) originalValue;
			break;
		case StatusEffect.Stat.FortifyMP:
			originalValue = (float) maxMP;
			maxMP += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
			maxMP = (int) originalValue;
			break;
		case StatusEffect.Stat.RegenHP:
			originalValue = HPRegenRate;
			HPRegenRate += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			HPRegenRate = originalValue;
			break;
		case StatusEffect.Stat.RegenSP:
			originalValue = SPRegenRate;
			SPRegenRate += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			SPRegenRate = originalValue;
			break;
		case StatusEffect.Stat.RegenMP:
			originalValue = MPRegenRate;
			MPRegenRate += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			MPRegenRate = originalValue;
			break;
		case StatusEffect.Stat.FortifyColdResistance:
			originalValue = coldResistance;
			coldResistance += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			coldResistance = originalValue;
			break;
		case StatusEffect.Stat.FortifyHeatResistance:
			originalValue = heatResistance;
			heatResistance += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			heatResistance = originalValue;
			break;
		case StatusEffect.Stat.FortifySTR:
			originalValue = STR;
			STR += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
			STR = Mathf.FloorToInt(originalValue);
			break;
		case StatusEffect.Stat.FortifyDEX:
			originalValue = DEX;
			DEX += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
			DEX = Mathf.FloorToInt(originalValue);
			break;
		case StatusEffect.Stat.FortifyWIS:
			originalValue = WIS;
			WIS += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
			WIS = Mathf.FloorToInt(originalValue);
			break;
		case StatusEffect.Stat.FortifyCHA:
			originalValue = CHA;
			CHA += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
			CHA = Mathf.FloorToInt(originalValue);
			break;
		case StatusEffect.Stat.FortifyArcane:
			originalValue = Arcane;
			Arcane += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
			Arcane = Mathf.FloorToInt(originalValue);
			break;
		case StatusEffect.Stat.FortifyAlchemy:
			originalValue = Alchemy;
			Alchemy += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
			Alchemy = Mathf.FloorToInt(originalValue);
			break;
		case StatusEffect.Stat.FortifySurvival:
			originalValue = Survival;
			Survival += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
 			Survival = Mathf.FloorToInt(originalValue);
			break;
		case StatusEffect.Stat.FortifyRepair:
			originalValue = Repair;
			Repair += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
			Repair = Mathf.FloorToInt(originalValue);
			break;
		case StatusEffect.Stat.FortifySecurity:
			originalValue = Security;
			Security += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
			Security = Mathf.FloorToInt(originalValue);
			break;
		case StatusEffect.Stat.FortifySpeech:
			originalValue = Speech;
			Speech += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
			Speech = Mathf.FloorToInt(originalValue);
			break;
		case StatusEffect.Stat.FortifyStealth:
			originalValue = Stealth;
			Stealth += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
			Stealth = Mathf.FloorToInt(originalValue);
			break;
		case StatusEffect.Stat.FortifyLightArmor:
			originalValue = LightArmor;
			LightArmor += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
			LightArmor = Mathf.FloorToInt(originalValue);
			break;
		case StatusEffect.Stat.FortifyMediumArmor:
			originalValue = MediumArmor;
			MediumArmor += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
			MediumArmor = Mathf.FloorToInt(originalValue);
			break;
		case StatusEffect.Stat.FortifyHeavyArmor:
			originalValue = HeavyArmor;
			HeavyArmor += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
			HeavyArmor = Mathf.FloorToInt(originalValue);
			break;
		case StatusEffect.Stat.FortifyBlock:
			originalValue = Block;
			Block += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
			Block = Mathf.FloorToInt(originalValue);
			break;
		case StatusEffect.Stat.FortifyOneHanded:
			originalValue = OneHanded;
			OneHanded += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
			OneHanded = Mathf.FloorToInt(originalValue);
			break;
		case StatusEffect.Stat.FortifyTwoHanded:
			originalValue = TwoHanded;
			TwoHanded += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
			TwoHanded = Mathf.FloorToInt(originalValue);
			break;
		case StatusEffect.Stat.FortifyMarksman:
			originalValue = Marksman;
			Marksman += Mathf.FloorToInt(statusEffect.potency);
			yield return new WaitForSeconds(statusEffect.duration);
			Marksman = Mathf.FloorToInt(originalValue);
			break;
		case StatusEffect.Stat.FortifyMovementSpeed:
			originalValue = movementSpeed;
			movementSpeed += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			movementSpeed = originalValue;
			break;
		case StatusEffect.Stat.FortifyXPGain:
			originalValue = XPGainRate;
			XPGainRate += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			XPGainRate = originalValue;
			break;
		default:
			throw new Exception("INVALID STAT");
		}
	}



	void OnValidate()
	{
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
