using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu]
public class SaveData : ScriptableObject
{
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


	//FIXME: why is String unrecognized?
	//public String Name;
	public Sex sex;
	public Race race;
	public int level;
	public int gold;
	public int carryWeightLimit;
	public List<GameObject> inventory = new List<GameObject>();
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
}
