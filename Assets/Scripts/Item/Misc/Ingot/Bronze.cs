using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Misc/Ingot/Bronze", fileName = "New Bronze")]
public sealed class Bronze : Ingot
{
    public sealed override int CalculateValue()
	{
		value = 150;
        return value;
	}
}
