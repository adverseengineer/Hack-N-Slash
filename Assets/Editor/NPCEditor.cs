using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(NPC))]
[CanEditMultipleObjects]
public class NPCEditor : Editor
{
    void OnSceneGUI()
    {
        NPC npc = (NPC) target;
        float angle = (npc.fov+npc.transform.eulerAngles.y)/2 * Mathf.Deg2Rad;
		Vector3 viewAngleA = new Vector3(Mathf.Sin(angle),0,Mathf.Cos(angle));
        Vector3 viewAngleB = new Vector3(Mathf.Sin(-angle),0,Mathf.Cos(-angle));

        //hearing
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(npc.transform.position, Vector3.up, npc.hearingDistance);

        //sight
		Handles.color = Color.cyan;
		Handles.DrawWireDisc(npc.transform.position, Vector3.up, npc.sightDistance);
		Handles.DrawLine(npc.transform.position, npc.transform.position + viewAngleA * npc.sightDistance);
		Handles.DrawLine(npc.transform.position, npc.transform.position + viewAngleB * npc.sightDistance);

        /*
        so i know you really miss your ex and i dont know how things ended between you two but i do know this:
        it may hurt like hell to do it, but to fully move on, you have to take them down off the pedestal. when you miss
        someone, you only remember the good things and your mind just ignores all the bad things about them that used
        to bother you
         */
    }
}
