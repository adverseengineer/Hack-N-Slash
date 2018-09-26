using UnityEngine;
//using UnityEngine.AI;
using System;
using System.Collections;

[AddComponentMenu("Actors/NPC")]
public sealed class NPC : MonoBehaviour
{
	public String name;
	public bool isFemale;
	public static float sightDistance;
	public static float fov;

	public TextAsset script;
	private NavMeshAgent agent;
	private Player player;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		if(agent != null)
			agent.autoTraverseOffMeshLink = true;
		else
			throw new Exception("<color=red>no navmesh agent component found on gameobject</color>");

		player = GameObject.FindWithTag("Player").GetComponent<Player>();
		if(player == null)
			throw new Exception("<color=red>no player found in scene hierarchy</color>");
	}

	void Update()
	{
		//detect if player is near and in front of the npc
		Vector3 rayDirection = player.gameObject.transform.localPosition - transform.localPosition;
		Vector3 NPCDirection = transform.TransformDirection(Vector3.forward);
		float angleDot = Vector3.Dot(rayDirection, NPCDirection);
		bool playerInFrontOfNPC = angleDot > 0.0f;
		bool playerCloseToNPC = rayDirection.sqrMagnitude < sightDistance*sightDistance;

		if (playerInFrontOfNPC && playerCloseToNPC)
		{
			RaycastHit hit;
			if (Physics.Raycast(transform.position, rayDirection, out hit, sightDistance) && hit.collider.gameObject == player.gameObject)
			{
				//talk to player
			}
		}
	}
}
