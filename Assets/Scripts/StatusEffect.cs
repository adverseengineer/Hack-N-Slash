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
		None = 									0,
		RestoreHP = 						1,
		RestoreSP = 						2,
		RestoreMP = 						3,
		RestoreFP = 						4,
		FortifyHP = 						5,
		FortifySP = 						6,
		FortifyMP = 						7,
		FortifyFP = 						8,
		RegenHP = 							9,
		RegenSP = 							10,
		RegenMP = 							11,
		RegenFP = 							12,
		FortifyColdResistance = 13,
		FortifyHeatResistance = 14,
		FortifySTR = 						15,
		FortifyDEX = 						16,
		FortifyWIS = 						17,
		FortifyCHA = 						18,
		FortifyArcane = 				19,
		FortifyAlchemy = 				20,
		FortifySurvival = 			21,
		FortifyRepair = 				22,
		FortifySecurity = 			23,
		FortifySpeech = 				24,
		FortifyBarter = 				25,
		FortifySneak = 					26,
		FortifyLightArmor = 		27,
		FortifyMediumArmor = 		28,
		FortifyHeavyArmor = 		29,
		FortifyBlock = 					30,
		FortifyOneHanded = 			31,
		FortifyTwoHanded = 			32,
		FortifyMarksman = 			33,
		FortifyMovementSpeed = 	34,
		FortifyXPGain = 				35,
	}
	public String title;
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
