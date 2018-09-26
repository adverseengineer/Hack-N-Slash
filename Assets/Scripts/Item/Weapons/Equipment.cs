using UnityEngine;

public class Equipment : Item
{
	public int currentDurability;
	public int maxDurability;

	public enum Buff
	{
		None = -1,
		DurabilityUp = 0,
		AttackUp = 1,
		DefenseUp = 2,
		CriticalHit = 3,
		Quickshot = 4,
		LongThrow = 5
	}
	public Buff buff;
}
