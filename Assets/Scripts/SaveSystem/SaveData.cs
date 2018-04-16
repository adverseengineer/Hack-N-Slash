using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu]
public class SaveData : ScriptableObject
{
	private Player player;

	//save
	public SaveData()
	{
		Debug.Log("creating save");
	}

	public static void Save()
	{
		Debug.Log("saved");
	}
}
