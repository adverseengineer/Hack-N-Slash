using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Camera/Mouse Look")]
public class MouseLook : MonoBehaviour
{
	//FIXME: i get stuck on the bottom of the screen whenever the mouse goes very far beyond it's limit

	public enum Axes { MouseX = 0, MouseY = 1, MouseXAndY = 2 };
	public Axes axes = Axes.MouseX;

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

	public int frameCounter = 10;

	public bool disabled = false;

	private Quaternion originalRotation;
	private Quaternion xQuaternion = Quaternion.identity;
	private Quaternion yQuaternion = Quaternion.identity;

	void Start ()
	{
		originalRotation = transform.localRotation;

		if (GetComponent<Rigidbody>() != null)
    {
      GetComponent<Rigidbody>().freezeRotation = true;
    }
	}

	void OnValidate()
	{
		if(frameCounter <= 0)
			frameCounter = 1;
	}

	void LateUpdate ()
	{
		rotAverageX = 0f;
		rotAverageY = 0f;

		//if looking is not disabled, take input
		if(!disabled)
		{
			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		}

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

		if(axes == Axes.MouseX && !disabled)
		{
			transform.localRotation = originalRotation * xQuaternion;
		}
		else if(axes == Axes.MouseY)
		{
			transform.localRotation = originalRotation * yQuaternion;
		}
		else
		{
			transform.localRotation = originalRotation * xQuaternion * yQuaternion;
		}
	}
}
