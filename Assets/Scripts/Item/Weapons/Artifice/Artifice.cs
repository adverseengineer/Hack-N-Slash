using UnityEngine;
using System.Collections;

public abstract class Artifice : Weapon
{
	//bomb
	//caltrops
	//beartraps
	public sealed override void CalculateValue()
	{
		//TODO: write item value formula for artifices
		value = 0;
	}
}
