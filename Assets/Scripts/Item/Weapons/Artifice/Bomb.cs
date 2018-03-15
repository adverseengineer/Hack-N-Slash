using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapons/Artifice/Bomb", fileName = "New Bomb")]
public class Bomb : Artifice
{
    public float blastMagnitude;

    void OnValidate()
    {
        CalculateValue();
    }
}
