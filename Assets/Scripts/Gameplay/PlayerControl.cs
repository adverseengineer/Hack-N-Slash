using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(CharacterController), typeof(Player), typeof(StatusEffectHandler))]
public class PlayerControl : MonoBehaviour
{
	private Camera cam;
	private Player player;
	private CharacterController cc;
	private StatusEffectHandler handler;
	private Animator animator;
	private Vector3 moveDirection = Vector3.zero;

	[Header("Movement")]
	public float baseMovementSpeed = 6.7f;
	public float crouchSpeedMultiplier = 0.52f;
	public float sprintSpeedMultiplier = 1.34f;
	public float jumpForce = 2f;
	private bool isCrouching = false;

	[Space(18)]

	[Header("Crouching")]
	public float crouchingHeight = 1f;
	private float originalColliderHeight;

	[Space(18)]

	[Header("FOV Kick")]
	public bool FOVKickEnabled = true;
	public FOVKick kick;

	void Start()
	{
		cam = transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Camera>();
		if(cam == null)
			throw new Exception("<color=red>no camera found in player hierarchy</color>");

		player = GetComponent<Player>();
		if(player == null)
			throw new Exception("<color=red>no player info found attached to player</color>");

		cc = GetComponent<CharacterController>();
		if(cc == null)
			throw new Exception("<color=red>no cc found attached to player</color>");
		else
		{
			originalColliderHeight = cc.height;
			crouchingHeight = originalColliderHeight / 2 - 1;
		}

		kick = new FOVKick(cam);
	}

	void Update()
	{
		//every frame, x and z of moveDirection is updated
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, Input.GetAxis("Vertical"));
		moveDirection.x *= baseMovementSpeed;
		moveDirection.z *= baseMovementSpeed;
		moveDirection = transform.TransformDirection(moveDirection);

		if(!player.swimming)
		{
			if(isCrouching)
			{
				moveDirection.x *= crouchSpeedMultiplier;
				moveDirection.z *= crouchSpeedMultiplier;
			}

			//crouch
			if(!Input.GetButton("Sprint") && !Input.GetButtonDown("Jump") && Input.GetButtonDown("Crouch") && cc.isGrounded)
			{
				print("ctrl");
				if(isCrouching) Stand();
				else Crouch();
			}

			//sprint
			else if(Input.GetButton("Sprint") && !Input.GetButtonDown("Jump") && !Input.GetButtonDown("Crouch") && cc.isGrounded) Sprint();

			//jump
			if(Input.GetButtonDown("Jump") && cc.isGrounded) Jump();


			//apply gravity
			moveDirection.y -= 9.81f * Time.deltaTime;
		}
		else
		{
			//SWIMMING CONTROLS
			moveDirection.y = 2 * Input.GetAxis("Jump");
			moveDirection.y -= 0.8f;

		}

		//perform this frame's movement
		cc.Move(moveDirection * Time.deltaTime);
	}

	void Crouch()
	{
		isCrouching = true;

		print("<color=purple>Crouch @ </color>" + Time.time);

		//adjust the characterController component's position and scale
		cc.height = crouchingHeight;
		cc.center = new Vector3(cc.center.x, crouchingHeight, cc.center.z);
	}

	void Stand()
	{
		isCrouching = false;
		
		print("<color=orange>Stand @ </color>" + Time.time);
		
		//adjust the characterController component's position and scale
		cc.center = new Vector3(cc.center.x, 0, cc.center.z);
		cc.height = originalColliderHeight;
	}

	void Sprint()
	{
		if(isCrouching) Stand();	

		print("<color=olive>Sprinting @ </color>" + Time.time);

		moveDirection.x *= sprintSpeedMultiplier;
		moveDirection.z *= sprintSpeedMultiplier;

		//if fovkick is enabled AND the player is moving AND the button has only just been pushed
		if(FOVKickEnabled && Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && Input.GetButtonDown("Sprint"))
		{
			StartCoroutine(kick.FOVKickUp());
		}
		else
		{
			StartCoroutine(kick.FOVKickDown());
		}
	}

	void Jump()
	{
		if(isCrouching) Stand();

		print("<color=navy>Jumping @ </color>" + Time.time);
		
		moveDirection.y = jumpForce;
	}

	void OnValidate()
	{
		if(GetComponent<CapsuleCollider>() != null && crouchingHeight < GetComponent<CapsuleCollider>().radius * 2)
		{
			crouchingHeight = GetComponent<CapsuleCollider>().radius * 2;
			throw new Exception("<color=red>crouching height cannot be less than the cc diameter</color>");
		}
	}
}
