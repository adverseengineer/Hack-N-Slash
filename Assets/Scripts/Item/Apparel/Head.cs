using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Items/Apparel/Head", fileName = "New Head")]
public sealed class Head : Apparel
{
	void OnValidate()
	{
		CalculateValue();
	}
}
