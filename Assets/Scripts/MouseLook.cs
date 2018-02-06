using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MouseLook : MonoBehaviour
{
	public enum Axes { MouseX = 0, MouseY = 1, MouseXAndY = 2 };
	public Axes axes = Axes.MouseX;

	public float sensitivityX = 15f;
	public float sensitivityY = 15f;
	public float minimumX = -360f;
	public float maximumX = 360f;
	public float minimumY = -60f;
	public float maximumY = 60f;

	private float rotationX = 0f;
	private float rotationY = 0f;
	private List<float> rotArrayX = new List<float>();
	private float rotAverageX = 0f;
	private List<float> rotArrayY = new List<float>();
	private float rotAverageY = 0f;

	public int frameCounter;

	public bool disable = false;

	private Quaternion originalRotation;
	private Quaternion xQuaternion = Quaternion.identity;
	private Quaternion yQuaternion = Quaternion.identity;

	void Start ()
	{
		originalRotation = transform.localRotation;
	}

	void OnValidate()
	{
		if(frameCounter <= 0)
			frameCounter = 1;
	}

	void Update ()
	{
		rotAverageX = 0f;
		rotAverageY = 0f;

		//if looking is not disabled, take input
		if(!disable)
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

		rotAverageX = Average(rotArrayX);
		rotAverageY = Average(rotArrayY);

		//restrict to the specified bounds
		rotAverageX = ClampAngle(rotAverageX, minimumX, maximumX);
		rotAverageY = ClampAngle(rotAverageY, minimumY, maximumY);

		//define each quaternion's axis so that each quaternion is equivalent to euler angles
		xQuaternion = Quaternion.AngleAxis (rotAverageX, Vector3.up);
		yQuaternion = Quaternion.AngleAxis (rotAverageY, Vector3.left);


		//TODO: map this to a better key
		if(Input.GetKeyDown(KeyCode.Q))
		{
			originalRotation = transform.localRotation;
			disable = !disable;
		}


		if(axes == Axes.MouseX && !disable)
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

	public static float Average(List<float> arg)
	{
		float result = 0f;
		foreach(float f in arg)
			result += f;
		return result / arg.Count;
	}

	public static float ClampAngle (float angle, float min, float max)
	{
		angle %= 360;
		if ((angle >= -360f) && (angle <= 360f))
		{
			if (angle < -360f)
			{
				angle += 360f;
			}
			if (angle > 360f)
			{
				angle -= 360f;
			}
		}
		return Mathf.Clamp (angle, min, max);
	}
}
