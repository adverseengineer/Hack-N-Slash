using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{
	private CharacterController cc;
	private Vector3 moveDirection = Vector3.zero;

	[Header("Movement")]
	public float baseMovementSpeed = 6.7f;
	public float crouchSpeedMultiplier = 0.52f;
	public float sprintSpeedMultiplier = 1.34f;
	public float swimSpeedMultiplier = 0.79f;
	public float gravity = 9.81f;
	private bool isCrouching = false;

	void Start()
	{
		cc = GetComponent<CharacterController>();
		if(cc == null)
			throw new Exception("<color=red>no cc found attached to player</color>");
	}

	void Update()
	{
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, Input.GetAxis("Vertical"));
		moveDirection.x *= baseMovementSpeed;
		moveDirection.z *= baseMovementSpeed;
		moveDirection = transform.TransformDirection(moveDirection);

		//if grounded but not climbing or swimming 

		//if holding sprint and grounded, but not holding jump or crouch, and not crouching
		if(Input.GetButton("Sprint") && !Input.GetButtonDown("Jump") && !Input.GetButtonDown("Crouch") && !isCrouching && cc.isGrounded)
		{
			moveDirection.x *= sprintSpeedMultiplier;
			moveDirection.z *= sprintSpeedMultiplier;
		}

		//if not crouching or holding crouch, but grounded and holding jump
		if(Input.GetButtonDown("Jump") && !Input.GetButtonDown("Crouch") && !isCrouching && cc.isGrounded)
			moveDirection.y = gravity;

		//apply gravity
		moveDirection.y -= gravity * Time.deltaTime;

		//perform this frame's movement
		cc.Move(moveDirection * Time.deltaTime);
	}
}
