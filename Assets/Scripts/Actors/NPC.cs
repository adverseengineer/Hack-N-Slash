using UnityEngine;
//using UnityEngine.AI;
using System;
using System.Collections;

[AddComponentMenu("Actors/NPC")]
[RequireComponent(typeof(NavMeshAgent))]
public sealed class NPC : Actor {

	//TODO: give npcs the same ability as the player to push things
	public enum CombatStyle
	{
		Berserker = 0, //dual wielding shortswords, medium or heavy armor
		Knight = 1, //longsword and shield, medium armor. just as God intended
		Ranger = 2, //longbow and arrow, light armor
		Artificer = 3, //heavy armor, crossbow, caltrops
		Thief = 4, //two daggers, light or medium armor
		Spellsword = 5, //longsword and spellbook or scroll, light armor
		Druid = 6, //light armor, staff and scroll
		Tank = 7 //heavy armor, warhammer or greatsword
		//TODO: add more archetypes
	};

	public bool essential;
	[Range(0,1f)] public float disposition = 0.5f;
	public CombatStyle combatStyle;

	private NavMeshAgent agent;

	public float hearingDistance;
	public float sightDistance;
	[Range(0,180)] public float fov;

	public Actor actorToFollow;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		agent.autoTraverseOffMeshLink = true;
	}

	void Update()
	{
		StartCoroutine(Follow(actorToFollow.transform, 5f));
	}

	public IEnumerator Idle()
	{	
		while(true)
		{
			yield return new WaitForEndOfFrame();
		}
	}
	public IEnumerator Follow(Transform target, float followDistance)
	{
		while(true)
		{
			if (Vector3.Distance(agent.destination, target.position) > followDistance)
        	{
           		agent.destination = target.position;
        	}
			yield return new WaitForEndOfFrame();
		}
	}
	public IEnumerator Search()
	{
		while(true)
		{
			yield return new WaitForEndOfFrame();
		}
	}
	public IEnumerator Attack()
	{
		while(true)
		{
			yield return new WaitForEndOfFrame();
		}
	}
	public IEnumerator Defend()
	{
		while(true)
		{
			yield return new WaitForEndOfFrame();
		}
	}
	public IEnumerator Retreat()
	{
		while(true)
		{
			yield return new WaitForEndOfFrame();
		}
	}
	public IEnumerator Converse()
	{
		while(true)
		{
			yield return new WaitForEndOfFrame();
		}
	}
}
