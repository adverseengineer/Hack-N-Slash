using UnityEngine;
using System;
using System.Collections;

public abstract class Item : ScriptableObject
{
	public int value;
	public float weight;

	public abstract void CalculateValue();
}
