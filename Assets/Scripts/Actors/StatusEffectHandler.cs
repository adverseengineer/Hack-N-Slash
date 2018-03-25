using UnityEngine;
using System.Collections;


public class StatusEffectHandler : MonoBehaviour
{
	//TODO: write this bullshit
	private Actor actor;

	void Start()
	{
		actor = GetComponent<Actor>();

		for(int i = 0; i < actor.activeEffects.Count; i++)
		{
			
		}
	}
}
