using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapons/Artifice/Beartrap", fileName = "New Beartrap")]
public class Beartrap : Artifice
{
    public uint damagePerSecond;

    void OnValidate()
    {
        CalculateValue();
    }
}
