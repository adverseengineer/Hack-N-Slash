using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (Creature))]
public class CreatureEditor : Editor
{
	void OnSceneGUI()
    {
		Creature creature = (Creature) target;
		Vector3 viewAngleA = creature.DirectionFromAngle(-creature.fov / 2);
        Vector3 viewAngleB = creature.DirectionFromAngle(creature.fov / 2);
		Handles.color = Color.yellow;
		Handles.DrawWireDisc(creature.transform.position, Vector3.up, creature.hearingDistance);
		Handles.color = Color.cyan;
		Handles.DrawWireDisc(creature.transform.position, Vector3.up, creature.sightDistance);
		Handles.DrawLine(creature.transform.position, creature.transform.position + viewAngleA * creature.sightDistance);
		Handles.DrawLine(creature.transform.position, creature.transform.position + viewAngleB * creature.sightDistance);
	}
}