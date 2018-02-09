using UnityEngine;
using System.Collections;

[AddComponentMenu("Item/Apparel/Ring")]
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
		value = CalculateValue();
	}
}
