using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Actors/Creature")]
[RequireComponent(typeof(NavMeshAgent))]
public class Creature : MonoBehaviour
{

	[Range(0f,180f)]
	public float fov;
	[Range(1f,100f)]
	public float sightDistance;
	[Range(1f,100f)]
	public float hearingDistance;

	private NavMeshAgent agent;
	private Animator animator;

	private Actor target;

	void OnEnable()
    {
        //DetectionEvent.OnGenerateDetectionEvent += Foo();
    }
    
    void OnDisable()
    {
        //DetectionEvent.OnGenerateDetectionEvent -= Foo();
    }

	void Foo()
	{
		print("shwoop");
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
			print("Idle...");
			//TODO: idle
			yield return new WaitForSeconds(3);
		}
	}

	public IEnumerator Investigate()
	{
		//TODO: investigate
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
