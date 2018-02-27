using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class FOVKick
{
	private Camera camera;//optional camera setup, if null the main camera will be used
	[HideInInspector] public float originalFov;//the original fov
	public float FOVIncrease = 3f;//the amount the field of view increases when going into a run
	public float TimeToIncrease = 1f;//the amount of time the field of view will increase over
	public float TimeToDecrease = 1f;//the amount of time the field of view will take to return to its original size
	public AnimationCurve IncreaseCurve;

	public FOVKick(Camera camera)
  	{
		if (camera == null)
    		throw new Exception("FOVKick camera is null, please supply the camera to the constructor");
   		if (IncreaseCurve == null)
    		throw new Exception("FOVKick Increase curve is null, please define the curve for the field of view kicks");
    	this.camera = camera;
    	originalFov = camera.fieldOfView;
	}

	public void ChangeCamera(Camera camera)
	{
		this.camera = camera;
	}

	public IEnumerator FOVKickUp()
	{
    	float t = Mathf.Abs((camera.fieldOfView - originalFov)/FOVIncrease);
    	while (t < TimeToIncrease)
    	{
      	camera.fieldOfView = originalFov + (IncreaseCurve.Evaluate(t/TimeToIncrease)*FOVIncrease);
     	t += Time.deltaTime;
    	yield return new WaitForEndOfFrame();
    	}
	}

	public IEnumerator FOVKickDown()
  	{
  		float t = Mathf.Abs((camera.fieldOfView - originalFov)/FOVIncrease);
    	while (t > 0)
    	{
    		camera.fieldOfView = originalFov + (IncreaseCurve.Evaluate(t/TimeToDecrease)*FOVIncrease);
    		t -= Time.deltaTime;
    		yield return new WaitForEndOfFrame();
    	}
    	//make sure that fov returns to the original size
    	camera.fieldOfView = originalFov;
	}
}
