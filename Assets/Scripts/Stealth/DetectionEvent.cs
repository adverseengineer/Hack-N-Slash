using UnityEngine;
using System.Collections;

public class DetectionEvent
{
    public float loudness;
    public Vector3 location;
    public delegate void GenerateDetectionEvent();
	public static GenerateDetectionEvent OnGenerateDetectionEvent;

    void OnGUI()
    {
        if(GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "Click"))
        {
            if(DetectionEvent.OnGenerateDetectionEvent != null)
                DetectionEvent.OnGenerateDetectionEvent();
        }
    }
}