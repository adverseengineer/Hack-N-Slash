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
	public int movementSpeed;//divide by 100 in all calculations
	public int XPGainRate;//divide by 100 in all calculations
	public Animator animator;
	public List<Item> inventory = new List<Item>();
	public List<StatusEffect> activeEffects = new List<StatusEffect>();

	[Space(6)]
	public int maxHP;
	public int currentHP;
	public int HPRegenRate;//measured in ppm (points per minute)

	[Space(6)]
	public int maxSP;
	public int currentSP;
	public int SPRegenRate;//measured in ppm (points per minute)

	[Space(6)]
	public int maxMP;
	public int currentMP;
	public int MPRegenRate;//measured in ppm (points per minute)

	[Space(18)]

	public int ATK; //atk - your unarmed attack power. increase by equiping a weapon
	public int DEF; //def - your unarmored defense. increase by equiping armor or a shield
	public int SPD; //spd - who hits first in a fight. higher speed means less chance of a counterattack

	[Space(18)]

	[Range(0,10)] public int STR; //STR - effectiveness of large melee weapons
	[Range(0,10)] public int DEX;//DEX - effectiveness of small melee weapons and ranged weapons
	[Range(0,10)] public int WIS; //WIS - effectiveness of spellbooks and staves
	[Range(0,10)] public int CHA; //CHA - effectiveness of all pacifist actions

	[Space(18)]

	//these five values need to be divided by 100 when used in calculations
	[Range(0,100)] public int heatResistance = 0;
	[Range(0,100)] public int coldResistance = 0;
	[Range(0,100)] public int evasionRate = 5;
	[Range(0,100)] public int criticalRate = 5;
	[Range(100,200)] public int criticalMult = 100;

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

	public Weapon EquippedWeapon;

	public Head EquippedHead;
	public Top EquippedTop;
	public Bottom EquippedBottom;
	public Shield EquippedShield;

	public Ring EquippedRing;
	public Earrings EquippedEarrings;
	public Amulet EquippedAmulet;
	public Belt EquippedBelt;

	[Space(18)]

	[Range(0,1f)] public float HeadCondition = 1f; //concussion
	[Range(0,1f)] public float TorsoCondition = 1f; //broken ribs
	[Range(0,1f)] public float LeftArmCondition = 1f; //trauma
	[Range(0,1f)] public float RightArmCondition = 1f; //trauma
	[Range(0,1f)] public float LeftLegCondition = 1f; //trauma
	[Range(0,1f)] public float RightLegCondition = 1f; //trauma


	public IEnumerator ApplyStatusEffect(StatusEffect statusEffect)
	{
		int originalValue = 0;
		//FIXME: implemented alchemy skill formula, ripped straight from new vegas
		//f(x)=3x/5+3
		//statusEffect.potency = statusEffect.potency * 3 / 5 + 3;
		switch(statusEffect.effect)
		{
		case StatusEffect.Effect.RestoreHP:
			currentHP += statusEffect.magnitude;
			break;
		case StatusEffect.Effect.RestoreSP:
			currentSP += statusEffect.magnitude;
			break;
		case StatusEffect.Effect.RestoreMP:
			currentMP += statusEffect.magnitude;
			break;
		case StatusEffect.Effect.FortifyHP:
			originalValue = maxHP;
			maxHP += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			maxHP = originalValue;
			break;
		case StatusEffect.Effect.FortifySP:
			originalValue = maxSP;
			maxSP += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			maxSP = originalValue;
			break;
		case StatusEffect.Effect.FortifyMP:
			originalValue = maxMP;
			maxMP += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			maxMP = originalValue;
			break;
		case StatusEffect.Effect.RegenHP:
			originalValue = HPRegenRate;
			HPRegenRate += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			HPRegenRate = originalValue;
			break;
		case StatusEffect.Effect.RegenSP:
			originalValue = SPRegenRate;
			SPRegenRate += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			SPRegenRate = originalValue;
			break;
		case StatusEffect.Effect.RegenMP:
			originalValue = MPRegenRate;
			MPRegenRate += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			MPRegenRate = originalValue;
			break;
		case StatusEffect.Effect.FortifyColdResistance:
			originalValue = coldResistance;
			coldResistance += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			coldResistance = originalValue;
			break;
		case StatusEffect.Effect.FortifyHeatResistance:
			originalValue = heatResistance;
			heatResistance += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			heatResistance = originalValue;
			break;
		case StatusEffect.Effect.FortifySTR:
			originalValue = STR;
			STR += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			STR = originalValue;
			break;
		case StatusEffect.Effect.FortifyDEX:
			originalValue = DEX;
			DEX += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			DEX = originalValue;
			break;
		case StatusEffect.Effect.FortifyWIS:
			originalValue = WIS;
			WIS += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			WIS = originalValue;
			break;
		case StatusEffect.Effect.FortifyCHA:
			originalValue = CHA;
			CHA += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			CHA = originalValue;
			break;
		case StatusEffect.Effect.FortifyArcane:
			originalValue = Arcane;
			Arcane += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			Arcane = originalValue;
			break;
		case StatusEffect.Effect.FortifyAlchemy:
			originalValue = Alchemy;
			Alchemy += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			Alchemy = originalValue;
			break;
		case StatusEffect.Effect.FortifySurvival:
			originalValue = Survival;
			Survival += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
 			Survival = originalValue;
			break;
		case StatusEffect.Effect.FortifyRepair:
			originalValue = Repair;
			Repair += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			Repair = originalValue;
			break;
		case StatusEffect.Effect.FortifySecurity:
			originalValue = Security;
			Security += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			Security = originalValue;
			break;
		case StatusEffect.Effect.FortifySpeech:
			originalValue = Speech;
			Speech += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			Speech = originalValue;
			break;
		case StatusEffect.Effect.FortifyStealth:
			originalValue = Stealth;
			Stealth += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			Stealth = originalValue;
			break;
		case StatusEffect.Effect.FortifyLightArmor:
			originalValue = LightArmor;
			LightArmor += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			LightArmor = originalValue;
			break;
		case StatusEffect.Effect.FortifyMediumArmor:
			originalValue = MediumArmor;
			MediumArmor += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			MediumArmor = originalValue;
			break;
		case StatusEffect.Effect.FortifyHeavyArmor:
			originalValue = HeavyArmor;
			HeavyArmor += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			HeavyArmor = originalValue;
			break;
		case StatusEffect.Effect.FortifyBlock:
			originalValue = Block;
			Block += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			Block = originalValue;
			break;
		case StatusEffect.Effect.FortifyOneHanded:
			originalValue = OneHanded;
			OneHanded += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			OneHanded = originalValue;
			break;
		case StatusEffect.Effect.FortifyTwoHanded:
			originalValue = TwoHanded;
			TwoHanded += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			TwoHanded = originalValue;
			break;
		case StatusEffect.Effect.FortifyMarksman:
			originalValue = Marksman;
			Marksman += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			Marksman = originalValue;
			break;
		case StatusEffect.Effect.FortifyMovementSpeed:
			originalValue = movementSpeed;
			movementSpeed += statusEffect.magnitude;
			yield return new WaitForSeconds(statusEffect.duration);
			movementSpeed = originalValue;
			break;
		case StatusEffect.Effect.FortifyXPGain:
			originalValue = XPGainRate;
			XPGainRate += statusEffect.magnitude;
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
	}
	*/
}
