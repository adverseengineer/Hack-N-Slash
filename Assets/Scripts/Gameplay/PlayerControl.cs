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
	private bool isCrouching = false;

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

	[Space(18)]

	[Header("Camera Shake")]
	public CameraShake cameraShake;

	void Start()
	{
		//FIXME: getcomponentinchildren might be the reason fov kick stopped working
		cam = GetComponentInChildren<Camera>();
		if(cam == null)
			throw new Exception("<color=red>no camera found attached to any child gameobjects</color>");
		player = GetComponent<Player>();
		if(player == null)
			throw new Exception("<color=red>no player info found attached to gameobject</color>");
		controller = GetComponent<CharacterController>();
		if(controller == null)
			throw new Exception("<color=red>no controller found attached to gameobject</color>");
		else
			originalHeight = controller.height;
		animator = GetComponent<Animator>();
		if(animator == null)
			throw new Exception("<color=red>no animator found attached to gameobject</color>");
		cameraShake = GetComponent<CameraShake>();
		if(cameraShake == null)
			throw new Exception("<color=red>no shake found attached to gameobject</color>");
		kick = new FOVKick(cam);
	}

	void Update()
	{
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= movementSpeed;

		if(isCrouching)
		{
			moveDirection *= crouchSpeedMultiplier;
		}

		//if not sprinting or jumping, toggle crouching
		if(!Input.GetButton("Sprint") && controller.isGrounded && Input.GetButtonDown("Crouch") && !Input.GetButtonDown("Jump"))
		{
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

		//if sprinting and grounded
		else if(Input.GetButton("Sprint") && controller.isGrounded)
		{
			StartCoroutine(Sprint());
		}

		//if holding space but not jump and grounded
		if(!Input.GetButton("Sprint") && Input.GetButton("Jump") && controller.isGrounded)
		{
			StartCoroutine(Jump());
		}

		//if holding shift and push spacebar and grounded
		else if(Input.GetButton("Sprint") && Input.GetButtonDown("Jump") && controller.isGrounded)
		{
			StartCoroutine(SprintingJump());
		}

		//if holding sprint and not grounded
		else if(Input.GetButton("Sprint") && !controller.isGrounded)
		{
			moveDirection.x *= airbourneSpeedMultiplier * sprintSpeedMultiplier;
			moveDirection.z *= airbourneSpeedMultiplier * sprintSpeedMultiplier;
		}

		else if(Input.GetButton("Jump") && controller.isGrounded && Input.GetAxis("Horizontal") == 0 &&  Input.GetAxis("Vertical") == 0)
		{
			print("<color=grey>NoInput @ </color>" + Time.time);
		}

		//apply gravity
		moveDirection.y -= gravity * Time.deltaTime;

		//execute this frame's movement
		controller.Move(moveDirection * Time.deltaTime);
	}

	IEnumerator Crouch()
	{
		print("<color=purple>Crouch @ </color>" + Time.time);

		//adjust the characterController component's position and scale
		controller.height = crouchingHeight;
		controller.center = new Vector3(controller.center.x, crouchingHeight / 2 - 1, controller.center.z);

		float t = Mathf.Abs((cam.transform.localPosition.y - originalHeight)/crouchingHeight);
    	while (t < crouchTimeToIncrease)
    	{
      		cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, originalHeight + (crouchHeightIncreaseCurve.Evaluate(t/crouchTimeToIncrease)*crouchingHeight), cam.transform.localPosition.z);
     		t += Time.deltaTime;
    		yield return new WaitForEndOfFrame();
    	}
		print("<color=purple>Camera has lerped down @ </color>" + Time.time);
	}

	IEnumerator Stand()
	{
		print("<color=orange>Stand @ </color>" + Time.time);

		//adjust the characterController component's position and scale
		controller.center = new Vector3(controller.center.x, 0, controller.center.z);
		controller.height = originalHeight;

		float t = Mathf.Abs((cam.transform.localPosition.y - originalHeight)/crouchingHeight);
    	while (t > 0)
    	{
    		cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, originalHeight + (crouchHeightIncreaseCurve.Evaluate(t/crouchTimeToDecrease)*crouchingHeight), cam.transform.localPosition.z);
    		t -= Time.deltaTime;
    		yield return new WaitForEndOfFrame();
    	}
		print("<color=orange>Camera has lerped up @ </color>" + Time.time);
    	//make sure that camera returns to the original height
    	cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, originalHeight, cam.transform.localPosition.z);
	}

	IEnumerator Sprint()
	{
		//if crouching, start standing up
		//this routine does not continue until Stand finishes
		if(isCrouching)
			yield return StartCoroutine(Stand());

		print("<color=olive>Sprinting @ </color>" + Time.time);
		moveDirection.x *= sprintSpeedMultiplier;
		moveDirection.z *= sprintSpeedMultiplier;

		//if fovkick is enabled AND the player is moving AND the button has only just been pushed
		if(FOVKickEnabled && moveDirection != Vector3.zero && Input.GetButtonDown("Sprint"))
		{
			StartCoroutine(kick.FOVKickUp());
		}
	}

	IEnumerator Jump()
	{
		//if crouching, start standing up
		//this routine does not continue until Stand finishes

		if(isCrouching)
			yield return StartCoroutine(Stand());
		
		print("<color=navy>Jumping @ </color>" + Time.time);
		
		//this gives the player some small control over their trajectory while airborne
		moveDirection.x += Input.GetAxis("Horizontal") * airbourneSpeedMultiplier;
		moveDirection.y = jumpSpeed;
		moveDirection.z += Input.GetAxis("Vertical") * airbourneSpeedMultiplier;
	}

	IEnumerator SprintingJump()
	{
		//if crouching, start standing up
		//this routine does not continue until Stand finishes
		if(isCrouching)
			yield return StartCoroutine(Stand());
		
		print("<color=teal>SprintJumping @ </color>" + Time.time);
		moveDirection.x *= sprintSpeedMultiplier;
		moveDirection.y = jumpSpeed;
		moveDirection.z *= sprintSpeedMultiplier;

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
			throw new Exception("<color=red>crouching height cannot be less than the controller radius * 2</color>");
		}
	}
}
