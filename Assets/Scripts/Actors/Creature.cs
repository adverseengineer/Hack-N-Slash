using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Actors/Creature")]
[RequireComponent(typeof(NavMeshAgent))]
public class Creature : MonoBehaviour
{

	[Range(0f,180f)]
	public float fov;
	[Range(0f,100f)]
	public float sightDistance;
	[Range(0f,100f)]
	public float hearingDistance;

	private NavMeshAgent agent;
	private Animator animator;

	private Actor target;

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
		animator = GetComponent<Animator>();
		StartCoroutine(Idle());
	}

	void Update()
	{
		//if an actor makes a sound or is seen
			//generate a DetectionEvent
			//set agent destination to that events location
	}

	public IEnumerator Idle()
	{
		while(true)
		{
			print("Idle @ " + Time.time);
			//TODO: idle
			yield return new WaitForSeconds(3);
		}
	}

	public IEnumerator Investigate(Vector3 location, float duration)
	{
		//head towards the point of interest
		//on the way there, if another sound is heard, change destination to that
		//once there, walk along a circular path X units from the point of interest
		//if nothing new is detected the whole time, return to patrolling

		//if the player sprints, the sound they make is dependent on equipped armor and weapons


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


	public IEnumerator Die()
	{
		//TODO: die
		yield return null;
	}

	public Vector3 DirectionFromAngle(float angleInDegrees)
	{
		angleInDegrees += transform.eulerAngles.y;
		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
	}
}
