using UnityEngine;
using System.Collections;

[AddComponentMenu("Items/Consumables/Potion")]
public sealed class Potion : Consumable
{
	public StatusEffect effect1;
	public StatusEffect effect2;
	public StatusEffect effect3;

	public sealed override void CalculateValue()
	{
		//TODO: fix this formula
		float averageMagnitude = (Mathf.Abs(effect1.magnitude) + Mathf.Abs(effect2.magnitude) + Mathf.Abs(effect3.magnitude)) / 3;
		float averageDuration = (effect1.duration + effect2.duration + effect3.duration) / 3;
		value = Mathf.FloorToInt((averageMagnitude + averageDuration) * (averageMagnitude + averageDuration) / 4);
	}

	void OnValidate()
	{
		CalculateValue();
		if(effect1.duration < 0) effect1.duration = 0;
		if(effect2.duration < 0) effect2.duration = 0;
		if(effect3.duration < 0) effect3.duration = 0;
	}
}
