using UnityEditor;
using UnityEngine;
using System.Collections;

// Custom Editor using SerializedProperties.
// Automatic handling of multi-object editing, undo, and prefab overrides.
[CustomEditor(typeof(NPC))]
[CanEditMultipleObjects]
public class MyPlayerEditor : Editor {
}