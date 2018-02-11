using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]

public class PlayerControl : MonoBehaviour
{
	public Camera cam;

	[Header("Movement")]
	public float sneakSpeed = 3.5f;
	public float walkSpeed = 6.7f;
	public float runSpeed = 9f;
	public float jumpSpeed = 20f;
  public float gravity = 50f;

	[Space(18)]

	[Header("Crouching")]
	public float crouchTimeToIncrease = 1f;
	public float crouchTimeToDecrease = 1f;
	private bool crouching = false;
	public AnimationCurve CrouchHeightIncreaseCurve;

	[Space(18)]

	[Header("Headbob")]
	public bool headBob = true;

	[Space(18)]

	[Header("FOV Kick")]
	public bool FOVKickEnabled = true;
	public FOVKick kick;

	[Space(18)]

	[Header("Physics")]
	public float pushPower = 2f;
	private float originalPushPower = 1f;



	private CharacterController controller;
	private Vector3 moveDirection = Vector3.zero;

	//when the start button is clicked
	void Start()
	{
		kick.Setup(cam);
		originalPushPower = pushPower;
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		pushPower = originalPushPower;
		if(controller.isGrounded)
		{
			pushPower = originalPushPower;
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
      moveDirection = transform.TransformDirection(moveDirection);

			//crouching
			if(Input.GetButtonDown("Fire1"))
			{
				crouching = !crouching;
				if(crouching)
				{
					//TODO: standing animation
				}
				else
				{
					//TODO: crouching animation
				}
			}



			//sprint
			if(Input.GetButton("Fire3"))
			{
				if(crouching)
				{
					crouching = false;
					//TODO: standing and leaning into run animation
				}
				pushPower *= runSpeed;
				moveDirection *= runSpeed;
				//if fovkick is enabled AND the player is moving AND they just pressed shift
				if(FOVKickEnabled && controller.velocity != Vector3.zero && Input.GetButtonDown("Fire3"))
				{
					StartCoroutine(kick.FOVKickUp());
				}
			}

			//if the player is neither crouching nor sprinting...
			else
			{
				pushPower *= walkSpeed;
				moveDirection *= walkSpeed;
				if(FOVKickEnabled && Input.GetButtonUp("Fire3"))
				{
					StartCoroutine(kick.FOVKickDown());
				}
			}

      if(Input.GetButtonDown("Jump") && !crouching)
			{
				moveDirection.y = jumpSpeed;
			}
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
//IDEA: two cameras, 1st person and 3rd person, set to different layers so that the player displays properly
