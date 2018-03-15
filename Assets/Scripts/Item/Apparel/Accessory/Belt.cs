using UnityEngine;

[CreateAssetMenu(menuName = "Items/Apparel/Belt", fileName = "New Belt")]
public sealed class Belt : Accessory
{
    //OneHanded
	//TwoHanded
	//carryWeightLimit
	//MediumArmor
	//HeavyArmor
	//SP
    void OnValidate()
	{
		CalculateValue();
	}
}
