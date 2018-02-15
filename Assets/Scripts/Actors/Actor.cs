using UnityEngine;
using System;
using System.Collections;
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
		case Stat.RestoreHP:
			currentHP += statusEffect.potency;
			break;
		case Stat.RestoreSP:
			currentSP += statusEffect.potency;
			break;
		case Stat.RestoreMP:
			currentMP += statusEffect.potency;
			break;
		case Stat.FortifyHP:
			originalValue = (float) maxHP;
			maxHP += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			maxHP = (int) originalValue;
			break;
		case Stat.FortifySP:
			originalValue = (float) maxSP;
			maxSP += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			maxSP = (int) originalValue;
			break;
		case Stat.FortifyMP:
			originalValue = (float) maxMP;
			maxMP += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			maxMP = (int) originalValue;
			break;
		case Stat.RegenHP:
			originalValue = HPRegenRate;
			HPRegenRate += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			HPRegenRate = originalValue;
			break;
		case Stat.RegenSP:
			originalValue = SPRegenRate;
			SPRegenRate += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			SPRegenRate = originalValue;
			break;
		case Stat.RegenMP:
			originalValue = MPRegenRate;
			MPRegenRate += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			MPRegenRate = originalValue;
			break;
		case Stat.FortifyColdResistance:
			originalValue = coldResistance;
			coldResistance += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			coldResistance = originalValue;
			break;
		case Stat.FortifyHeatResistance:
			originalValue = heatResistance;
			heatResistance += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			heatResistance = originalValue;
			break;
		case Stat.FortifySTR:
			originalValue = STR;
			STR += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			STR = originalValue;
			break;
		case Stat.FortifyDEX:
			originalValue = DEX;
			DEX += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			DEX = originalValue;
			break;
		case Stat.FortifyWIS:
			originalValue = WIS;
			WIS += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			WIS = originalValue;
			break;
		case Stat.FortifyCHA:
			originalValue = CHA;
			CHR += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			CHA = originalValue;
			break;
		case Stat.FortifyArcane:
			originalValue = Arcane;
			Arcane += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			Arcane = originalValue;
			break;
		case Stat.FortifyAlchemy:
			originalValue = Alchemy;
			Alchemy += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			Alchemy = originalValue;
			break;
		case Stat.FortifySurvival:
			originalValue = Survival;
			Survival += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
 			Survival = originalValue;
			break;
		case Stat.FortifyRepair:
			originalValue = Repair;
			Repair += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			Repair = originalValue;
			break;
		case Stat.FortifySecurity:
			originalValue = Security;
			Security += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			Security = originalValue;
			break;
		case Stat.FortifySpeech:
			originalValue = Speech;
			Speech += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			Speech = originalValue;
			break;
		case Stat.FortifyStealth:
			originalValue = Stealth;
			Stealth += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			Stealth = originalValue;
			break;
		case Stat.FortifyLightArmor:
			originalValue = LightArmor;
			LightArmor += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			LightArmor = originalValue;
			break;
		case Stat.FortifyMediumArmor:
			originalValue = MediumArmor;
			MediumArmor += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			MediumArmor = originalValue;
			break;
		case Stat.FortifyHeavyArmor:
			originalValue = HeavyArmor;
			HeavyArmor += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			HeavyArmor = originalValue;
			break;
		case Stat.FortifyBlock:
			originalValue = Block;
			Block += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			Block = originalValue;
			break;
		case Stat.FortifyOneHanded:
			originalValue = OneHanded;
			OneHanded += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			OneHanded = originalValue;
			break;
		case Stat.FortifyTwoHanded:
			originalValue = TwoHanded;
			TwoHanded += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			TwoHanded = originalValue;
			break;
		case Stat.FortifyMarksman:
			originalValue = Marksman;
			Marksman += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			Marksman = originalValue;
			break;
		case Stat.FortifyMovementSpeed:
			originalValue = movementSpeed;
			movementSpeed += statusEffect.potency;
			yield return new WaitForSeconds(statusEffect.duration);
			movementSpeed = originalValue;
			break;
		case Stat.FortifyXPGain:
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
