using UnityEngine;
using System;
using System.Collections;

public abstract class Item : MonoBehaviour
{
	public String Name;
	public int value;
	public float weight;

	public abstract void CalculateValue();
}
