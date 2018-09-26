using System;
using UnityEngine;

[Serializable]
public struct Boost
{
	[Range(1,3)]
	public int potency;

	public enum Effect
	{
		None = -1,
		AttackUp = 0,
		DefenseUp = 1,
		StealthUp = 2,
		LandSpeedUp = 3,
		ClimbSpeedUp = 4,
		SwimSpeedUp = 5,
		HeatResistanceUp = 6,
		FireResistance = 7,
		FrostResistance = 8,
		ShockResistance = 9,
		Hearty = 10,
		Endura = 11
	}

	public Effect effect;

	public Boost(Effect effect, int potency = 1)
	{

		this.effect = effect;
		this.potency = potency;
	}
}
