using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Items/Apparel/Torso", fileName = "New Torso")]
public sealed class Torso : Apparel
{
	void OnValidate()
	{
		CalculateValue();
	}
}
