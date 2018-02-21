using System;
using System.Collections;

[Serializable]
public class StatusEffect
{
	public enum Effect
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
		FortifySecurity = 19,
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

	public String source;
	public uint duration;
	public bool canExpire;	
	public bool isBeneficial;
	public bool canStack;
	public Effect effect;
	public int magnitude;
	public StatusEffect(
		String source,
		uint duration,
		bool canExpire,
		bool isBeneficial,
		bool canStack,
		Effect effect,
		int magnitude)
	{
		this.source = source;
		this.duration = duration;
		this.canExpire = canExpire;
		this.isBeneficial = isBeneficial;
		this.canStack = canStack;
		this.effect = effect;
		this.magnitude = magnitude;
	}
}
