using System;
using System.Collections;

[Serializable]
public class StatusEffect
{
	public enum Stat
	{
		//restore/drain
		//fortify/damage
		//regen/degen
		RestoreHP = 0,
		RestoreSP = 1,
		RestoreMP = 2,
		FortifyHP = 3,
		FortifySP = 4,
		FortifyMP = 5,
		RegenHP = 6,
		RegenSP = 7,
		RegenMP = 8,
		FortifyColdResistance = 9,
		FortifyHeatResistance = 10,
		FortifySTR = 11,
		FortifyDEX = 12,
		FortifyWIS = 13,
		FortifyCHA = 14,
		FortifyArcane = 15,
		FortifyAlchemy = 16,
		FortifySurvival = 17,
		FortifyRepair = 18,
		FortifySecurity = 29,
		FortifySpeech = 20,
		FortifyStealth = 21,
		FortifyLightArmor = 22,
		FortifyMediumArmor = 23,
		FortifyHeavyArmor = 24,
		FortifyBlock = 25,
		FortifyOneHanded = 26,
		FortifyTwoHanded = 27,
		FortifyMarksman = 28,
		FortifyMovementSpeed = 29,
		FortifyXPGain = 30,
	}
	public String title;
	public Stat stat;
	public float potency;
	public int duration;

	public StatusEffect(Stat stat, float magnitude, int duration)
	{
		this.stat = stat;
		this.magnitude = magnitude;
		this.duration = duration;
	}
}
