using UnityEngine;
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
	public float airbourneSpeedMultiplier = 0.283582089552f;
	public float sneakSpeedMultiplier = 0.522388059701f;
	public float runSpeedMultiplier = 1.34328358209f;
	public float jumpSpeed = 20f;
  	public float gravity = 50f;
	private bool isCrouching;

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
	public float pushPowerMultiplier = 1f;
	public float weight = 100f;

	void Start()
	{
		cam = GetComponentInChildren<Camera>();
		player = GetComponent<Player>();
		controller = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		kick = new FOVKick(cam);
	}

	void Update()
	{
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
   		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= movementSpeed;

		controller.Move(Vector3.zero);//Move must be called in order for isGrouded to return true on the first frame
		if(controller.isGrounded)
		{
			print("GROUNDED");

			//toggle sneaking
			if(Input.GetButtonDown("Sneak"))
			{
				isCrouching = !isCrouching;
				if(isCrouching)
				{
					moveDirection *= sneakSpeedMultiplier;
					animator.Play("Sneak");
				}
				else
				{
					moveDirection /= sneakSpeedMultiplier;
					animator.Play("Idle");
				}
			}

			//if running
			if(Input.GetButton("Sprint"))
			{
				print("running @ " + Time.time);

				//stand up if not already
				if(isCrouching)
				{
						isCrouching = false;
						animator.Play("Idle");
				}

				moveDirection.x *= runSpeedMultiplier;
				moveDirection.z *= runSpeedMultiplier;

				//if fovkick is enabled AND the player is moving AND the button has only just been pushed
				if(FOVKickEnabled && moveDirection != Vector3.zero && Input.GetButtonDown("Sprint"))
				{
					print("kick @ " + Time.time);
					StartCoroutine(kick.FOVKickUp());
				}
				
				player.currentSP--;
			}

			//if jumping
			if(Input.GetButtonDown("Jump"))
			{
				print("jump @ " + Time.time + "Y̴̧̛͇̰̱̣͈̹̫͔̺͓̜͇̫̭̰̰̱̮E̸̛͚̝̠Ȩ̡̢͙̙̟̬͉̝̬̟̠̝͖̣̝̠͓͘͢ͅT̞̮̹̼͓͕͢");

				//stand up if not already
				if(isCrouching)
				{
						isCrouching = false;
						animator.Play("Idle");
				}

				moveDirection.y += jumpSpeed;
			}
		}

		moveDirection.y -= gravity * Time.deltaTime;

		//finally execute this movement that i've cooked up
		controller.Move(moveDirection * Time.deltaTime);
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
 	{
    	Vector3 force;
		if(hit.collider.attachedRigidbody == null || hit.collider.attachedRigidbody.isKinematic) return;
		if(hit.moveDirection.y < -0.3)
		{
			force = new Vector3(0,-0.5f,0) * 20 * weight;
     	}
		else
		{
        	force = hit.controller.velocity * pushPowerMultiplier;
		}
    	hit.collider.attachedRigidbody.AddForceAtPosition(force, hit.point);
 	}
}
//TODO: two cameras, 1st person and 3rd person, set to different layers so that the player displays properly
