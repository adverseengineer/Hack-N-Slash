using UnityEngine;
using System;
using System.Collections;

public abstract class Item : ScriptableObject
{
	public Sprite Icon;
	
	[TextArea]
	public String description;

	public int value;
}
