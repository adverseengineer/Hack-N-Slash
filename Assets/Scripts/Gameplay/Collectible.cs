using UnityEngine;
using System;

public class Collectible : MonoBehaviour
{
    public static LayerMask mask = 9;

    public Item representedItem;

    void OnValidate()
    {
        gameObject.tag = "collectible";
        gameObject.layer = mask;
    }
}
