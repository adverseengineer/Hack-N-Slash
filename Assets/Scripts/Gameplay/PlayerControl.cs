using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(CharacterController), typeof(Player), typeof(StatusEffectHandler))]
public class PlayerControl : MonoBehaviour
{
	private Camera cam;
	private Player player;
	private CharacterController controller;
	private StatusEffectHandler handler;
	private Animator animator;
	private Vector3 moveDirection = Vector3.zero;

	[Header("Movement")]
	public float movementSpeed = 6.7f;
	public float airbourneSpeedMultiplier = 0.28f;
	public float crouchSpeedMultiplier = 0.52f;
	public float sprintSpeedMultiplier = 1.34f;
	public float jumpSpeed = 20f;
  	public float gravity = 50f;
	private bool isCrouching;

	[Space(18)]

	[Header("Crouching")]
	public float crouchingHeight = 1f;
	public float crouchTimeToIncrease = 1f;
	public float crouchTimeToDecrease = 1f;
	public AnimationCurve crouchHeightIncreaseCurve;
	private float originalHeight;

	[Space(18)]

	[Header("Headbob")]
	public bool headBob = true;
	//TODO: Implement headbob

	[Space(18)]

	[Header("FOV Kick")]
	public bool FOVKickEnabled = true;
	public FOVKick kick;


	void Start()
	{
		cam = GetComponentInChildren<Camera>();
		if(cam == null)
			throw new Exception("no camera found attached to any child gameobjects");
		player = GetComponent<Player>();
		if(player == null)
			throw new Exception("no player info found attached to gameobject");
		controller = GetComponent<CharacterController>();
		if(controller != null)
			originalHeight = controller.height;
		else
			throw new Exception("no controller found attached to gameobject");
		animator = GetComponent<Animator>();
		if(animator == null) throw new Exception("no animator found attached to gameobject");
		kick = new FOVKick(cam);
	}

	void Update()
	{

		if(controller.isGrounded)
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
   			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= movementSpeed;

			if(Input.GetButtonDown("Crouch"))
			{
				print("ctrl" + Time.time);
				isCrouching = !isCrouching;
				if(isCrouching)
				{
					StartCoroutine(Crouch());
				}
				else
				{
					StartCoroutine(Stand());
				}
			}


			if(Input.GetButton("Sprint"))
			{
				Sprint();
			}
			if(Input.GetButtonDown("Jump"))
			{
				print("SHART");
				moveDirection.y = jumpSpeed;
			}
		}

		moveDirection.y -= gravity * Time.deltaTime;

		controller.Move(moveDirection * Time.deltaTime);
	}

	IEnumerator Crouch()
	{
		print("crouch" + Time.time);

		//adjust the characterController component's position and scale
		controller.height = crouchingHeight;
		controller.center = new Vector3(controller.center.x, crouchingHeight / 2 - 1, controller.center.z);
		yield return null;
		// float t = Mathf.Abs((cam.transform.localPosition.y - originalHeight)/crouchDistance);
    	// while (t < crouchTimeToIncrease)
    	// {
      	// 	cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, originalHeight + (crouchHeightIncreaseCurve.Evaluate(t/crouchTimeToIncrease)*crouchDistance), cam.transform.localPosition.z);
     	// 	t += Time.deltaTime;
    	// 	yield return new WaitForEndOfFrame();
    	// }
	}

	IEnumerator Stand()
	{
		print("stand" + Time.time);

		//adjust the characterController component's position and scale
		controller.center = new Vector3(controller.center.x, 0, controller.center.z);
		controller.height = originalHeight;
		yield return null;
		// float t = Mathf.Abs((cam.transform.localPosition.y - originalHeight)/crouchDistance);
    	// while (t > 0)
    	// {
    	// 	cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, originalHeight + (crouchHeightIncreaseCurve.Evaluate(t/crouchTimeToDecrease)*crouchDistance), cam.transform.localPosition.z);
    	// 	t -= Time.deltaTime;
    	// 	yield return new WaitForEndOfFrame();
    	// }
    	// //make sure that camera returns to the original height
    	// cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, originalHeight, cam.transform.localPosition.z);
	}

	void Sprint()
	{
		moveDirection.x *= sprintSpeedMultiplier;
		moveDirection.z *= sprintSpeedMultiplier;

		//if fovkick is enabled AND the player is moving AND the button has only just been pushed
		if(FOVKickEnabled && moveDirection != Vector3.zero && Input.GetButtonDown("Sprint"))
		{
			StartCoroutine(kick.FOVKickUp());
		}
	}

	void OnValidate()
	{
		if(GetComponent<CharacterController>() != null && crouchingHeight < GetComponent<CharacterController>().radius * 2)
		{
			crouchingHeight = GetComponent<CharacterController>().radius * 2;
			throw new Exception("crouching height must always be greater than the controller's diameter");
		}
	}
}
