using UnityEngine;

[CreateAssetMenu(menuName = "Items/Equipment/Weapon", fileName = "New Weapon")]
public sealed class Weapon : Equipment
{
	public bool twoHanded;
	public int attack;
}
