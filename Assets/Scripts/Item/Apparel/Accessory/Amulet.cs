using UnityEngine;

[CreateAssetMenu(menuName = "Items/Apparel/Amulet", fileName = "New Amulet")]
public sealed class Amulet : Accessory
{
    //HP regen
    //SP Regen
    //MP Regen
    //Movement speed
    //carry weight
    void OnValidate()
	{
		CalculateValue();
	}
}
