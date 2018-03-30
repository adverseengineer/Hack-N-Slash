using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NPC))]
[CanEditMultipleObjects]
public class NPCEditor : Editor
{
    void OnSceneGUI()
    {
        NPC npc = (NPC) target;
        float angle = (npc.fov / 2 + npc.transform.eulerAngles.y) * Mathf.Deg2Rad;
		Vector3 viewAngleA = new Vector3(Mathf.Sin(angle),0,Mathf.Cos(angle));
        angle = (npc.fov / 2 - npc.transform.eulerAngles.y) * Mathf.Deg2Rad;
        Vector3 viewAngleB = new Vector3(Mathf.Sin(-angle),0,Mathf.Cos(-angle));

        //hearing
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(npc.transform.position, Vector3.up, npc.hearingDistance);
        Handles.DrawWireDisc(npc.transform.position, Vector3.right, npc.hearingDistance);
        Handles.DrawWireDisc(npc.transform.position, Vector3.forward, npc.hearingDistance);

        //sight
		Handles.color = Color.cyan;
		Handles.DrawWireDisc(npc.transform.position, Vector3.up, npc.sightDistance);
		Handles.DrawLine(npc.transform.position, npc.transform.position + viewAngleA * npc.sightDistance);
		Handles.DrawLine(npc.transform.position, npc.transform.position + viewAngleB * npc.sightDistance);
    }
}
