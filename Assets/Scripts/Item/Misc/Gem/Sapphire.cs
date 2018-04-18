using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Misc/Gem/Sapphire", fileName = "New Sapphire")]
public sealed class Sapphire : Gem
{
    public sealed override int CalculateValue()
	{
		value = 1300;
        return value;
	}
}
