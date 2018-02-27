using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController), typeof(Player), typeof(StatusEffectHandler))]
public class PlayerControl : MonoBehaviour
{
	public Camera cam;

	private Player player;
	private CharacterController controller;
	private Vector3 moveDirection = Vector3.zero;
	private StatusEffectHandler handler;
	private Animator animator;

	[Header("Movement")]
	public float movementSpeed = 6.7f;
	public float airbourneSpeedMultiplier = 0.283582089552f;
	public float sneakSpeedMultiplier = 0.522388059701f;
	public float runSpeedMultiplier = 1.34328358209f;
	public float jumpSpeed = 20f;
  	public float gravity = 50f;
	private bool isCrouching;
	private bool wasSprintingLastFrame;

	[Space(18)]

	[Header("Crouching")]
	public float crouchTimeToIncrease = 1f;
	public float crouchTimeToDecrease = 1f;
	public AnimationCurve crouchHeightIncreaseCurve;

	[Space(18)]

	[Header("Headbob")]
	public bool headBob = true;
	//TODO: Implement headbob

	[Space(18)]

	[Header("FOV Kick")]
	public bool FOVKickEnabled = true;
	public FOVKick kick;

	[Space(18)]

	[Header("Physics")]
	public float pushPower = 2f;
	public float pushPowerSneakMultiplier = 0.55f;
	public float pushPowerRunMultiplier = 1.7f;

	void Start()
	{
		kick = new FOVKick(cam);
		player = GetComponent<Player>();
		controller = GetComponent<CharacterController>();
		handler = GetComponent<StatusEffectHandler>();
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
   		moveDirection = transform.TransformDirection(moveDirection);

		wasSprintingLastFrame = false;

		if(controller.isGrounded)
		{
			//crouching
			if(Input.GetButtonDown("Fire1"))
			{
				isCrouching = !isCrouching;
				if(isCrouching)
				{
					//TODO: standing animation
				}
				else
				{
					//TODO: crouching animation
				}
			}

			//if sprinting and crouching
			if(Input.GetButton("Fire3") && isCrouching)
			{
				wasSprintingLastFrame = true;
				isCrouching = false;
				//TODO: stand up and sprint animation blend

				moveDirection *= runSpeedMultiplier;
				pushPower *= pushPowerRunMultiplier;

				//if fovkick is enabled AND the player is moving AND the button has only just been pushed
				if(FOVKickEnabled && controller.velocity != Vector3.zero && Input.GetButtonDown("Fire3"))
					StartCoroutine(kick.FOVKickUp());

				//TODO: decrease SP
			}

			//if sprinting but not crouching
			else if(Input.GetButton("Fire3") && !isCrouching)
			{
				wasSprintingLastFrame = true;

				moveDirection *= runSpeedMultiplier;
				pushPower *= pushPowerRunMultiplier;

				//if fovkick is enabled AND the player is moving AND the button has only just been pushed
				if(FOVKickEnabled && controller.velocity != Vector3.zero && Input.GetButtonDown("Fire3"))
					StartCoroutine(kick.FOVKickUp());

				//TODO: decrease SP
			}

			//if crouching but not sprinting
			else if(!Input.GetButton("Fire3" ) && isCrouching)
			{
				wasSprintingLastFrame = false;

				moveDirection *= sneakSpeedMultiplier;
				pushPower *= pushPowerSneakMultiplier;

				if(FOVKickEnabled && Input.GetButtonUp("Fire3"))
					StartCoroutine(kick.FOVKickDown());
			}

			//if neither crouching nor sprinting
			else if(!Input.GetButton("Fire3") && !isCrouching)
			{
				wasSprintingLastFrame = false;

				if(FOVKickEnabled && Input.GetButtonUp("Fire3"))
					StartCoroutine(kick.FOVKickDown());
			}

			//if jumping and crouching
			else if(Input.GetButtonDown("Jump") && isCrouching)
			{
				isCrouching = false;
				moveDirection.y = jumpSpeed;
			}

			//if jumping, but not crouching
			else if(Input.GetButtonDown("Jump") && !isCrouching)
			{
				moveDirection.y = jumpSpeed;
			}
    	}
		//if not grounded, and was sprinting last frame
		else if(!controller.isGrounded && wasSprintingLastFrame)
		{
			moveDirection *= runSpeedMultiplier;
		}

		//if not grounded and wasnt sprinting last frame
		else if(!controller.isGrounded && !wasSprintingLastFrame)
		{
			moveDirection *= airbourneSpeedMultiplier;
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		//pushing objects with your body
		if (hit.collider.attachedRigidbody == null || hit.collider.attachedRigidbody.isKinematic || hit.moveDirection.y < -hit.controller.stepOffset)
			return;

		hit.collider.attachedRigidbody.velocity = hit.moveDirection * pushPower / hit.collider.attachedRigidbody.mass;

		if(hit.gameObject.tag == "platform")
		{
			this.transform.parent = hit.gameObject.transform;
		}
	}
}
//TODO: two cameras, 1st person and 3rd person, set to different layers so that the player displays properly
