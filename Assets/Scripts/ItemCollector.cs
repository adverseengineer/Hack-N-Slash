using UnityEngine;
using System.Collections;

public class ItemCollector : MonoBehaviour
{

	private Player player;

	// Use this for initialization
	void Start ()
	{
		player = GetComponent<Player>();
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnControllerColliderStay(Collision collision)
	{
		Debug.Log("hitting!");
		if(collision.gameObject.tag == "collectible")
		{
			if(Input.GetKey(KeyCode.E))
	    {
				collision.gameObject.SetActive(false);
	    }
		}
  }
}
