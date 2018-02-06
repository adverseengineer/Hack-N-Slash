using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]

public class PlayerControl : MonoBehaviour
{
	public enum Direction { up = 0, down = 1 };

	[Header("Movement")]
	public float walkingSpeed = 3.5f;
	public float runningSpeed = 6.7f;
	public float sprintingSpeed = 9f;
	public float jumpSpeed = 20f;
  public float gravity = 50f;


	[Header("Physics")]
	public float pushPower = 2f;
	private float originalPushPower = 0f;
	[Space(20)]


	public Camera cam;


	[Header("Crouching")]
	private bool crouched = false;
	private float standingHeight;
	public float crouchDistance = 1f;
	public float crouchTimeToIncrease = 1f;
	public float crouchTimeToDecrease = 1f;
	public AnimationCurve CrouchHeightIncreaseCurve;


	[Header("Headbob")]
	public bool headBob = true;
	public AnimationCurve HeadBobIncreaseCurve;


	[Header("FOV Kick")]
	public bool FOVKick = true;
	private float originalFOV;
	public float FOVIncrease = 3f;
	public float FOVTimeToIncrease = 1f;
	public float FOVTimeToDecrease = 1f;
	public AnimationCurve FOVIncreaseCurve;


	private CharacterController controller;
	private Vector3 moveDirection = Vector3.zero;

	//when the start button is clicked
	void Start()
	{
		originalPushPower = pushPower;
		originalFOV = cam.fieldOfView;
		standingHeight = cam.transform.localPosition.y;
		controller = GetComponent<CharacterController>();
		if(cam == null)
		{
			Debug.Log("no camera assigned, creating new");
			//TODO: handle this error
		}
	}

	void Update()
	{
		//if the player is touching the ground...
		if(controller.isGrounded)
		{
			//reset this frame's pushPower
			pushPower = originalPushPower;

			//set a vector equal to the player input...
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

			//convert it to worldspace...
      moveDirection = transform.TransformDirection(moveDirection);

			//if the player pushes ctrl (crouch)
			if(Input.GetButtonDown("Fire1"))
			{
				if(crouched){}
					//TODO: UNCROUCH
				else{}
					//TODO: CROUCH
			}
			//sprint
			if(Input.GetButton("Fire3"))
			{
				pushPower *= sprintingSpeed;
				moveDirection *= sprintingSpeed;
				//if fovkick is enabled AND the player is moving, kick up the fov
				if(FOVKick && controller.velocity != Vector3.zero)
				{
					//TODO: KICKUP
				}

				//if the player is crouched, uncrouch them
				if(crouched)
				{
					//TODO: KICKDOWN
				}
			}
			else if(crouched)
			{
				pushPower *= walkingSpeed;
				moveDirection *= walkingSpeed;
			}
			//if the player is neither crouching or sprinting...
			else
			{
				pushPower *= runningSpeed;
				moveDirection *= runningSpeed;
				if(FOVKick && controller.velocity != Vector3.zero)
				{
					//TODO: KICKDOWN
				}
			}

      if(Input.GetButtonDown("Jump"))
			{
				moveDirection.y = jumpSpeed;
				if(crouched)
				{
					//TODO: UNCROUCH
				}
			}
    }
		//keep the player sticking to the ground
    moveDirection.y -= gravity * Time.deltaTime;
		//execute the movement that's been made
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



	public IEnumerator MoveByCurve(AnimationCurve curve, Direction direction, float time, float originalValue, float currentValue, float increment)
  {
  	float t = Mathf.Abs((currentValue - originalValue)/increment);
		if(direction == Direction.up)
		{
	    while (t < time)
	    {
	    	currentValue = originalValue + (curve.Evaluate(t/time)*increment);
	      t += Time.deltaTime;
	      yield return new WaitForEndOfFrame();
	    }
		}
		else if(direction == Direction.down)
		{
			while (t > 0)
	    {
	    	cam.fieldOfView = originalFOV + (FOVIncreaseCurve.Evaluate(t/FOVTimeToDecrease)*FOVIncrease);
	      t -= Time.deltaTime;
	      yield return new WaitForEndOfFrame();
	    }
		}
	}
}
//IDEA: two cameras, 1st person and 3rd person, set to different layers so that the player displays properly
