using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(NPC))]
[AddComponentMenu("Actors/Vendor")]
class Vendor : MonoBehaviour
{
    public List<Item> stock = new List<Item>(0);
}
