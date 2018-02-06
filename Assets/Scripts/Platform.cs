using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	private bool occupied = false;
	private int occupancy = 0;
	void OnCollisionEnter(Collision hit)
	{
		//if the thing that hit the platform is the player or has a Rigidbody
		if(hit.gameObject.GetComponent<Rigidbody>() != null)
		{
			occupancy++;
			hit.transform.parent = this.transform;
		}
	}

	void OnCollisionExit(Collision hit)
	{
		if(hit.gameObject.GetComponent<Rigidbody>() != null)
		{
			occupancy--;
			hit.transform.parent = null;
		}
	}

	void LateUpdate()
	{
		if(occupancy > 0){occupied = true;}
		else{occupied = false;}
	}
}
