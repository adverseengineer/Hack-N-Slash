using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Camera/Mouse Look")]
public class MouseLook : MonoBehaviour
{
	//FIXME: i get stuck on the bottom of the screen whenever the mouse goes very far beyond it's limit

	public float sensitivityX = 15f;
	public float sensitivityY = 15f;
	public float minimumX = -Mathf.Infinity;
	public float maximumX = Mathf.Infinity;
	public float minimumY = -80f;
	public float maximumY = 90f;

	private float rotationX = 0f;
	private float rotationY = 0f;
	private List<float> rotArrayX = new List<float>();
	private float rotAverageX = 0f;
	private List<float> rotArrayY = new List<float>();
	private float rotAverageY = 0f;

	[Range(0,60)] public uint frameCounter = 10;
	private Transform child;
	private Quaternion originalRotation;
	private Quaternion originalChildRotation;
	private Quaternion xQuaternion = Quaternion.identity;
	private Quaternion yQuaternion = Quaternion.identity;

	

	void Start ()
	{
		child = transform.GetChild(0);//cam rig

		originalRotation = transform.localRotation;
		originalChildRotation = child.transform.localRotation;

		if (GetComponent<Rigidbody>() != null)
    	{
      		GetComponent<Rigidbody>().freezeRotation = true;
    	}
	}

	void LateUpdate ()
	{
		//TODO: this
		//store the current distance between camera and player
		//cast a line between the camera and the player
			//while there is something between them
				//move closer
				
				

		rotAverageX = 0f;
		rotAverageY = 0f;

		rotationX += Input.GetAxis("Mouse X") * sensitivityX;
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

		rotArrayX.Add(rotationX);
		rotArrayY.Add(rotationY);

		//if the list is at capacity, remove the oldest item
		if (rotArrayX.Count >= frameCounter)
			rotArrayX.RemoveAt(0);
		if (rotArrayY.Count >= frameCounter)
			rotArrayY.RemoveAt(0);

		rotAverageX = Functions.Average(rotArrayX);
		rotAverageY = Functions.Average(rotArrayY);

		//restrict to the specified bounds
		rotAverageX = Functions.ClampAngle(rotAverageX, minimumX, maximumX);
		rotAverageY = Functions.ClampAngle(rotAverageY, minimumY, maximumY);

		//define each quaternion's axis so that each quaternion is equivalent to euler angles
		xQuaternion = Quaternion.AngleAxis (rotAverageX, Vector3.up);
		yQuaternion = Quaternion.AngleAxis (rotAverageY, Vector3.left);

		transform.localRotation = originalRotation * xQuaternion;
		transform.GetChild(0).transform.localRotation = originalChildRotation * yQuaternion;
	}
}
