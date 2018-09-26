using UnityEngine;
using System.Collections;

public class TextureSwirl : MonoBehaviour
{
	public float radius = 1f;
	public float speed = 1f;

	[Range(0,2*Mathf.PI)] public float testValue;

	private Renderer renderer;

	void Awake()
	{
		renderer = GetComponent<MeshRenderer>();
	}

	void Update()
	{
		renderer.sharedMaterial.mainTextureOffset = new Vector2(Mathf.Cos(Time.time * speed), Mathf.Sin(Time.time * speed)) * radius;
	}

	void OnValidate()
	{
		renderer = GetComponent<MeshRenderer>();
		renderer.sharedMaterial.mainTextureOffset = new Vector2(Mathf.Cos(testValue), Mathf.Sin(testValue));
	}
}
