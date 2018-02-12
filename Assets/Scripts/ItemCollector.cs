using UnityEngine;
using System.Collections;

//this class is to be attached to the camera
public class ItemCollector : MonoBehaviour
{
	private Player player;

	public LayerMask mask = 7;
	public float maxDistance = 5;

	void Start ()
	{
		player = GetComponent<Player>();
	}

	void FixedUpdate()
  {
    RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
    if (Physics.Raycast(transform.position, fwd, out hit, maxDistance, mask.value))
		{
      print("Found an object: " + hit.transform.gameObject.name);
			if(Input.GetKeyDown(KeyCode.E))
			{
				hit.transform.gameObject.SetActive(false);
			}
		}
  }
}
