using UnityEngine;
//using UnityEngine.AI;
using System;
using System.Collections;

[AddComponentMenu("Actors/NPC")]
[RequireComponent(typeof(NavMeshAgent))]
public sealed class NPC : Actor {

	//TODO: give npcs the same ability as the player to push things

	//Berserker		dual wielding shortswords, medium or heavy armor
	//Knight		longsword and shield, medium armor. just as God intended
	//Ranger		longbow and arrow, light armor
	//Artificer		heavy armor, crossbow, caltrops
	//Thief			two daggers, light or medium armor
	//Spellsword	longsword and spellbook or scroll, light armor
	//Druid			light armor, staff and scroll
	//Tank			heavy armor, warhammer or greatsword

	//TODO: add more archetypes

	public bool essential;
	[Range(0,1f)] public float disposition = 0.5f;

	private NavMeshAgent agent;

	private Player player;

	public float hearingDistance;
	public float sightDistance;
	[Range(0,180)] public float fov;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		if(agent != null)
			agent.autoTraverseOffMeshLink = true;
		else
			throw new Exception("<color=red>no navmesh agent component found on gameobject</color>");

		player = GameObject.FindWithTag("player").GetComponent<Player>();
		if(player == null)
			throw new Exception("<color=red>no player found in scene hierarchy</color>");
	}

	void Update()
	{
		StartCoroutine(Idle());
	}

	public IEnumerator Idle()
	{	
		while(true)
		{
			if(Vector3.Distance(transform.position, player.transform.position) <= sightDistance)
			{
				if(true)//player is within fov)
				{
					transform.LookAt(player.transform);
				}
			}
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
