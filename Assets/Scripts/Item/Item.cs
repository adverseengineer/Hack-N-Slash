using UnityEngine;
using System;
using System.Collections;

public abstract class Item : ScriptableObject
{
	public Sprite Icon;
	public string name;
	[TextArea]
	public String description;

	public int value;
	public float weight;
	public bool stolen;

	public abstract int CalculateValue();
}
