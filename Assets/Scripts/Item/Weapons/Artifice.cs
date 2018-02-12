using UnityEngine;
using System.Collections;

[AddComponentMenu("Items/Weapons/Artifice")]
public sealed class Artifice : Weapon
{
	//bomb
	//caltrops
	//beartraps
	public sealed override void CalculateValue()
	{
		//TODO: write item value formula for artificies
		value = 0;
	}
}
