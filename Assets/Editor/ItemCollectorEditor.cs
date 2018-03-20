using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (ItemCollector))]
public class ItemCollectorEditor : Editor
{
	void OnSceneGUI()
    {
		ItemCollector itemCollector = (ItemCollector) target;
        Vector3 fwd = itemCollector.transform.localPosition;
        fwd.z += itemCollector.maxDistance;
		Handles.color = Color.cyan;
        Debug.Log(fwd.x + " " + fwd.y + " " + fwd.z);
		Handles.DrawLine(itemCollector.transform.position, fwd);
	}
}
