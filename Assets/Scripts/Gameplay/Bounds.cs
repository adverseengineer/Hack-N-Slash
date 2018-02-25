using UnityEngine;
using System.Collections;

public class Bounds : MonoBehaviour {

	public Color color;
	public Vector3 spawnPoint = Vector3.zero;
	public Vector3 max = Vector3.zero;
	public Vector3 min = Vector3.zero;

	// Update is called once per frame
	void Update () {
		if(
			gameObject.transform.position.x < min.x || gameObject.transform.position.y < min.y ||
			gameObject.transform.position.z < min.z || gameObject.transform.position.x > max.x ||
			gameObject.transform.position.y > max.y || gameObject.transform.position.z > max.z
		){
			gameObject.transform.position = spawnPoint;
		}
	}

	void OnValidate()
	{
		color.a = 255;
	}
	
	void OnDrawGizmosSelected()
	{
		Vector3 size = new Vector3(max.x - min.x, max.y - min.y, max.z - min.z);
		Vector3 center = new Vector3((max.x + min.x) / 2, (max.y + min.y) / 2, (max.z + min.z) / 2);
		Gizmos.color = color;
		Gizmos.DrawWireCube(center, size);
		Gizmos.DrawWireSphere(spawnPoint, 1);
	}
}
