using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Camera-Control/Mouse Orbit")]
public class MouseOrbit : MonoBehaviour
{
	public Camera cam;

	public float minimumDistance = 1;
	public float maximumDistance = 15;
  public float distance = 5.0f;

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

	public int frameCounter = 10;

	public bool disabled = false;

	private Quaternion originalRotation;
	private Quaternion xQuaternion = Quaternion.identity;
	private Quaternion yQuaternion = Quaternion.identity;


  // Use this for initialization
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
    if (cam)
    {
			rotAverageX = 0f;
			rotAverageY = 0f;

			if(!disabled)
			{
				rotationX += Input.GetAxis("Mouse X") * sensitivityX;
      	rotationY -= Input.GetAxis("Mouse Y") * sensitivityY;
			}

			if(Input.GetAxis("Mouse X") * sensitivityX != 0)
			{
				Debug.Log("x");
			}

			if(Input.GetAxis("Mouse Y") * sensitivityY != 0)
			{
				Debug.Log("y");
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

			rotAverageX = Functions.ClampAngle(rotAverageX, minimumX, maximumX);
			rotAverageY = Functions.ClampAngle(rotAverageY, minimumY, maximumY);

			xQuaternion = Quaternion.AngleAxis (rotAverageX, Vector3.up);
			yQuaternion = Quaternion.AngleAxis (rotAverageY, Vector3.left);

			transform.localRotation = originalRotation * xQuaternion * yQuaternion;

			distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, minimumDistance, maximumDistance);
			/*



    	RaycastHit hit;
			float distanceLost = 0f;
      if (Physics.Linecast (target.position, transform.position, out hit))
      {
        distance -=  hit.distance;
				distanceLost = hit.distance;
      }
			else
			{
				distance += distanceLost;
			}
      Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
      Vector3 newPosition = newRotation * negDistance + target.position;
       transform.rotation = newRotation;
      transform.position = newPosition;
			*/
		}
  }
}
