using UnityEngine;
using System;
using System.Collections;


public class StatusEffectHandler : MonoBehaviour
{
	private Actor actor;

	void Start()
	{
		actor = GetComponent<Actor>();
		if(actor == null)
			throw new Exception("no actor found attached to gameobject");

		StartCoroutine(IncreaseNeeds());
	}

	public IEnumerator IncreaseNeeds()
	{
		while(true)
		{
			actor.fatigue++;
			actor.hunger++;
			actor.thirst++;

			if(actor.swimming)
			{
				actor.breath -= 0.02f;
				if(actor.breath <= 0)
				{
					//actor.Die();
					print(gameObject.name + " drowned @ " + Time.time);
				}
			}

			if(actor.fatigue >= 500)
			{
				actor.Die();
				print(gameObject.name + " collapsed from sleep deprivation @ " + Time.time);
			}

			if(actor.hunger >= 500)
			{
				actor.Die();
				print(gameObject.name + " starved to death @ " + Time.time);
			}

			if(actor.thirst >= 500)
			{
				actor.Die();
				print(gameObject.name + " became terminally dehydrated @ " + Time.time);
			}

			yield return new WaitForSeconds(1);
		}
	}
}
