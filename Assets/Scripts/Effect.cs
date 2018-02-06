using UnityEngine;
using System.Collections;

public class Effect
{
	float magnitude;
	int duration;
	public enum Eff
	{
		//restore/drain
		RestoreHP = 0,
		RestoreSP = 1,
		RestoreMP = 2,
		RestoreFP = 3,
		//fortify/damage
		FortifyHP = 4,
		FortifySP = 5,
		FortifyMP = 6,
		FortifyFP = 7,
		//regen/degen
		RegenHP = 8,
		RegenSP = 9,
		RegenMP = 10,
		RegenFP = 11,
		FortifyColdResistance = 12,
		FortifyHeatResistance = 13,
		FortifySTR = 14,
		FortifyDEX = 15,
		FortifyWIS = 16,
		FortifyCHA = 17,
		FortifyElemental = 		18,
		FortifyHealing = 			19,
		FortifyRepair = 			20,
		FortifySecurity = 		21,
		FortifySurvival = 		22,
		FortifyAlchemy = 			23,
		FortifySpeech = 			24,
		FortifyBarter = 			25,
		FortifyOneHanded = 		26,
		FortifyTwoHanded = 		27,
		FortifyArchery = 			28,
		FortifyBlock = 				29,
		FortifyLightArmor = 	30,
		FortifyMediumArmor = 	31,
		FortifyHeavyArmor = 	32,
		FortifySneak = 				33
	}
	public Eff effect;

	public Effect(Eff effect, float magnitude, int duration)
	{
		this.effect = effect;
		this.magnitude = magnitude;
		this.duration = duration;
	}
}
