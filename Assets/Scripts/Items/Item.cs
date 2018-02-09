using UnityEngine;
using System;
using System.Collections;

public abstract class Item : MonoBehaviour
{
	public int value;
	public float weight;

	public abstract int CalculateValue();
}
