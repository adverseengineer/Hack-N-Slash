using UnityEngine;

[CreateAssetMenu(menuName = "Items/Apparel/Ring", fileName = "New Ring")]
public sealed class Ring : Accessory
{
    //Arcane
    //Alchemy
    //Speech
    //Barter
    //Sneak
    //Marksman
    void OnValidate()
	{
		CalculateValue();
	}
}