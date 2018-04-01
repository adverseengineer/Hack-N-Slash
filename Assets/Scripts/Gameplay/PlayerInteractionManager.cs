using UnityEngine;
using System;
using System.Collections;

//this class is to be attached to the camera
public class PlayerInteractionManager : MonoBehaviour
{
	private Player player;
	private Camera cam;

	public LayerMask mask = 7;
	public float maxDistance = 5;

	private Transform grandparent;

	void Start ()
	{
		grandparent = transform.parent.transform.parent;

		player = grandparent.GetComponent<Player>();
		if(player == null)
			throw new Exception("no player info found on grandparent transform");

		cam = GetComponent<Camera>();
		if(cam == null)
			throw new Exception("no camera found attached to gameobject");
	}

	void Update()
  {
		//declare a RaycastHit struct to store the hit info
    RaycastHit hit;

		//construct a ray that starts at the camera and passes through the center of the screen
    Ray romano = cam.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));

		Debug.DrawRay(romano.origin, romano.direction * maxDistance, Color.yellow);

		if(Physics.Raycast(romano, out hit, maxDistance, mask))
		{
      		//print("Found an object: " + hit.transform.gameObject.name);
			if(Input.GetKeyDown(KeyCode.E))
			{
				if(hit.transform.gameObject.tag == "collectible")
				{
					player.inventory.Add(hit.transform.gameObject.GetComponent<Collectible>().representedItem);
					hit.transform.gameObject.SetActive(false);
				}
				else if(hit.transform.gameObject.tag == "NPC")
				{
					print(DialogueManager.LoadDialogue(hit.transform.gameObject.GetComponent<NPC>().script.name, 0));
				}
			}
		}
  }

	void OnValidate()
	{
		if(maxDistance < 0) maxDistance = 0;
	}
}
