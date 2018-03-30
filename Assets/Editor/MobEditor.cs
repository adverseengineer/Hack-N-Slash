using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Mob))]
[CanEditMultipleObjects]
public class MobEditor : Editor
{
	void OnSceneGUI()
    {
		Mob mob = (Mob) target;
		float angle = (mob.fov+mob.transform.eulerAngles.y)/2 * Mathf.Deg2Rad;
		Vector3 viewAngleA = new Vector3(Mathf.Sin(angle),0,Mathf.Cos(angle));
        Vector3 viewAngleB = new Vector3(Mathf.Sin(-angle),0,Mathf.Cos(-angle));

		//hearing
		Handles.color = Color.yellow;
		Handles.DrawWireDisc(mob.transform.position, Vector3.up, mob.hearingDistance);
		Handles.DrawWireDisc(mob.transform.position, Vector3.right, mob.hearingDistance);
		Handles.DrawWireDisc(mob.transform.position, Vector3.forward, mob.hearingDistance);

		//sight
		Handles.color = Color.cyan;
		Handles.DrawWireDisc(mob.transform.position, Vector3.up, mob.sightDistance);
		Handles.DrawLine(mob.transform.position, mob.transform.position + viewAngleA * mob.sightDistance);
		Handles.DrawLine(mob.transform.position, mob.transform.position + viewAngleB * mob.sightDistance);
	}
}
