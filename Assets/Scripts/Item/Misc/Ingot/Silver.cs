using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Misc/Ingot/Silver", fileName = "New Silver")]
public sealed class Silver : Ingot
{
    public sealed override int CalculateValue()
	{
		value = 800;
        return value;
	}
}
