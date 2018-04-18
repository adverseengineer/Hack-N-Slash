using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Misc/Gem/Emerald", fileName = "New Emerald")]
public sealed class Emerald : Gem
{
    public sealed override int CalculateValue()
	{
		value = 1500;
        return value;
	}
}
