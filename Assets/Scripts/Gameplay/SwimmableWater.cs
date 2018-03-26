using UnityEngine;
using System;

[RequireComponent(typeof(BoxCollider))]
public class SwimmableWater : MonoBehaviour
{
    public Color waterColor = Color.blue;

	private Renderer rend;

	void Start()
	{
		rend = GetComponent<Renderer>();
	}

    //when a collider enters the water
    void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.GetComponent<Actor>() != null)
        {
            other.gameObject.GetComponent<Actor>().swimming = true;
        }
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.GetComponent<Actor>() != null)
        {
            other.gameObject.GetComponent<Actor>().swimming = false;
        }
	}

	void OnValidate()
	{
		rend = GetComponent<Renderer>();
		rend.sharedMaterial.color = waterColor;
	}
}
