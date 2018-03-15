using UnityEngine;

[CreateAssetMenu(menuName = "Items/Apparel/Earring", fileName = "New Earring")]
public sealed class Earring : Accessory
{
    //heatResistance
    //coldResistance
    //water breathing
    void OnValidate()
	{
		CalculateValue();
	}
}