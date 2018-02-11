using UnityEngine;
using System.Collections;

//this class is to be attached to the camera
public class ItemCollector : MonoBehaviour
{
	private Player player;

	void Start ()
	{
		player = GetComponent<Player>();
	}

	void Update()
  {
    Vector3 fwd = transform.TransformDirection(Vector3.forward);
    if (Physics.Raycast(transform.position, fwd, 10))
      Debug.Log("There is something in front of the object!");
  }
}
