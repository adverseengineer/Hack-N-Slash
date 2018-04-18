using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Misc/Gem/Diamond", fileName = "New Diamond")]
public sealed class Diamond : Gem
{
    public sealed override int CalculateValue()
	{
		value = 1800;
        return value;
	}
}
