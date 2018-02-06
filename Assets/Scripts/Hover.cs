using UnityEngine;
using System.Collections;
public class Hover : MonoBehaviour {

	public enum Mode { sine = 0, pingpong = 1, custom = 2};
	public Mode mode = Mode.custom;
	public AnimationCurve customCurve;
	[Range(0f, 200f)]
	public float angularVelocity = 1;
	[Range(0f, 50f)]
	public float frequency = 1;
	[Range(0f, 50f)]
	public float amplitude = 1;
	[Range(0, (float) 2 * Mathf.PI)]
	public float phase;
	public Vector3 translation = Vector3.zero;
	public Vector3 rotation = Vector3.zero;

	void Update ()
	{
		transform.Rotate(rotation * angularVelocity * Time.deltaTime, Space.World);

		switch(mode)
		{
		case Mode.sine:
			if(frequency == 0)
				transform.Translate(translation * Mathf.Sin(Time.time + phase) * amplitude * Time.deltaTime, Space.World);
			else
				transform.Translate(translation * Mathf.Sin(Time.time / frequency + phase) * amplitude * Time.deltaTime, Space.World);
			break;
		case Mode.pingpong:
			float ft = frequency * Time.time;
			float v = (ft - Mathf.Floor(ft)) * amplitude * (-1 + 2 * (Mathf.Floor(ft) % 2)) - amplitude * (Mathf.Floor(ft) % 2) + amplitude / 2;
			transform.Translate(translation * v * Time.deltaTime, Space.World);
			break;
		case Mode.custom:
			//TODO: implement the custom animation curve
			break;
		}

	}
}
