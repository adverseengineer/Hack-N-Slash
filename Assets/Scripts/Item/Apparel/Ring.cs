using UnityEngine;
using System.Collections;

[AddComponentMenu("Items/Apparel/Ring")]
public sealed class Ring : Apparel
{
	//Arcane
	//Alchemy
	//Speech
	//Barter
	//Sneak
	//Marksman
	void OnValidate()
	{
		CalculateValue();
	}
}
