using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NPC))]
[CanEditMultipleObjects]
public class NPCEditor : Editor
{
    void OnSceneGUI()
    {
        NPC npc = (NPC) target;
        float angle = (NPC.fov / 2 + npc.transform.eulerAngles.y) * Mathf.Deg2Rad;
		Vector3 viewAngleA = new Vector3(Mathf.Sin(angle),0,Mathf.Cos(angle));
        angle = (NPC.fov / 2 - npc.transform.eulerAngles.y) * Mathf.Deg2Rad;
        Vector3 viewAngleB = new Vector3(Mathf.Sin(-angle),0,Mathf.Cos(-angle));
		
        //sight
		Handles.color = Color.cyan;
		Handles.DrawWireDisc(npc.transform.position, Vector3.up, NPC.sightDistance);
		Handles.DrawLine(npc.transform.position, npc.transform.position + viewAngleA * NPC.sightDistance);
		Handles.DrawLine(npc.transform.position, npc.transform.position + viewAngleB * NPC.sightDistance);
    }
}
