using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapons/Artifice/Caltrop", fileName = "New Caltrop")]
public class Caltrop : Artifice
{
    public uint damagePerSecond;

    void OnValidate()
    {
        CalculateValue();
    }
}
