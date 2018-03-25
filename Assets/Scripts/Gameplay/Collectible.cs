using UnityEngine;
using System;

public class Collectible : MonoBehaviour
{
    public static LayerMask mask = 9;

    public Item representedItem;

    void OnValidate()
    {
        if(gameObject.tag != "collectible")
        {
            gameObject.tag = "collectible";
            throw new Exception("tag cannot be changed whilst gameobject has Collectible component attached");
        }

        if(gameObject.layer != mask)
        {
            gameObject.layer = mask;
            throw new Exception("layer cannot be changed whilst gameobject has Collectible component attached");
        }
    }
}
