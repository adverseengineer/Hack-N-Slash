using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class StatusEffect
{
	public enum Effect
	{
		//restore/drain
		//fortify/damage
		//regen/degen
		RestoreHP = 						0,
		RestoreSP = 						1,
		RestoreMP = 						2,
		RestoreFP = 						3,
		FortifyHP = 						4,
		FortifySP = 						5,
		FortifyMP = 						6,
		FortifyFP = 						7,
		RegenHP = 							8,
		RegenSP = 							9,
		RegenMP = 							10,
		RegenFP = 							11,
		FortifyColdResistance = 12,
		FortifyHeatResistance = 13,
		FortifySTR = 						14,
		FortifyDEX = 						15,
		FortifyWIS = 						16,
		FortifyCHA = 						17,
		FortifyArcane = 				18,
		FortifyAlchemy = 				19,
		FortifySurvival = 			20,
		FortifyRepair = 				21,
		FortifySecurity = 			22,
		FortifySpeech = 				23,
		FortifyBarter = 				24,
		FortifySneak = 					25,
		FortifyLightArmor = 		26,
		FortifyMediumArmor = 		27,
		FortifyHeavyArmor = 		28,
		FortifyBlock = 					29,
		FortifyOneHanded = 			30,
		FortifyTwoHanded = 			31,
		FortifyMarksman = 			32,
	}
	public Effect effect;
	public float magnitude;
	public int duration;
	
	public StatusEffect(Effect effect, float magnitude, int duration)
	{
		this.effect = effect;
		this.magnitude = magnitude;
		this.duration = duration;
	}
}
