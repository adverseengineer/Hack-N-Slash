using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Misc/Ingot/Gold", fileName = "New Gold")]
public sealed class Gold : Ingot
{
    public sealed override int CalculateValue()
	{
		value = 900;
        return value;
	}
}
