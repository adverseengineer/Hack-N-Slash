using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Actors/Mob")]
[RequireComponent(typeof(NavMeshAgent))]
public class Mob : MonoBehaviour
{

	[Range(0f,180f)]
	public float fov;
	[Range(0f,100f)]
	public float sightDistance;
	[Range(0f,100f)]
	public float hearingDistance;
	public Vector3 roamSpace;
	[Range(0f,100f)]
	public float roamDistance;
	[Range(0f,1f)]
	public float chanceToMove;

	private NavMeshAgent agent;

	[SerializeField]
	private GameObject playerObject;

    void OnEnable()
	{
		//StealthEventManager.OnClicked += Investigate;
	}

    void OnDisable() 
	{
		//StealthEventManager.OnClicked -= Investigate;
	}

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		StartCoroutine(Idle());
	}

	void Update()
	{
		//if an actor makes a sound or is seen
			//generate a DetectionEvent
			//set agent destination to that events location

		Vector3 rayDirection = playerObject.transform.localPosition - transform.localPosition;
		Vector3 enemyDirection = transform.TransformDirection(Vector3.forward);
		float angleDot = Vector3.Dot(rayDirection, enemyDirection);
		bool playerInFrontOfEnemy = angleDot > 0.0f;
		bool playerCloseToEnemy = rayDirection.sqrMagnitude < sightDistance*sightDistance;

		if (playerInFrontOfEnemy && playerCloseToEnemy)
		{
			RaycastHit hit;
			if (Physics.Raycast(transform.position, rayDirection, out hit, sightDistance) && hit.collider.gameObject == playerObject)
			{
				StopCoroutine("Idle");
			}
		}
	}

	public IEnumerator Idle()
	{
		while(true)
		{
			//TODO: idle
			if(Random.value <= chanceToMove)
			{
				Vector2 movement = Random.insideUnitCircle;
				agent.destination = transform.position + new Vector3(movement.x,0,movement.y);
			}
			yield return new WaitForSeconds(1);
		}
	}

	public IEnumerator Investigate(Vector3 location, float duration)
	{
		//head towards the point of interest
		//on the way there, if another sound is heard, change destination to that
		//once there, walk along a circular path X units from the point of interest
		//if nothing new is detected the whole time, return to patrolling

		//TODO: investigate
		agent.destination = location;

		float timeLimit = Time.time + duration;
		while(true)
		{
			if(Time.time > timeLimit)
			{
				break;
			}
		}
		yield return null;
	}

	public IEnumerator Attack()
	{
		//TODO: attack
		yield return null;
	}
}
